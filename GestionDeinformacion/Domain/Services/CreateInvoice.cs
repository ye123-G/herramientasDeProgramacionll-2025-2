using GestionDeinformacion.Domain.Model;
using GestionDeinformacion.Domain.ports;
using Microsoft.Graph;

namespace GestionDeinformacion.Domain.Services
{
    internal class CreateInvoice
    {
        private readonly IPatientPort patientPort;
        private readonly IInvoicePorts invoicePort;
        private readonly IOrderPorts orderPort;

        public CreateInvoice(
            IPatientPort patientPort,
            IInvoicePorts invoicePort,
            IOrderPorts orderPort)
        {
            this.patientPort = patientPort;
            this.invoicePort = invoicePort;
            this.orderPort = orderPort;
        }

        public Invoice Execute(
            string patientId,
            string doctorName,
            IList<string> orderNumbers,
            decimal accumulatedCopayYear)
        {
            if (string.IsNullOrWhiteSpace(patientId))
                throw new ArgumentException("La cédula del paciente es obligatoria.");

            if (string.IsNullOrWhiteSpace(doctorName))
                throw new ArgumentException("El nombre del médico tratante es obligatorio.");

            if (orderNumbers == null || orderNumbers.Count == 0)
                throw new ArgumentException("Debe seleccionar al menos una orden para facturar.");

            // 1. Obtener paciente e información de póliza
            var patientObj = patientPort.FindById(patientId);
            var patient = patientObj as Patient
                          ?? throw new InvalidOperationException("Paciente no encontrado.");

            // Corregir el acceso a BirthDate (asegurar que es DateTime)
            DateTime birthDate;
            if (patient.BirthDate is DateTime bd)
                birthDate = bd;
            else
                throw new InvalidOperationException("Fecha de nacimiento inválida.");

            var today = DateTime.Today;
            var age = today.Year - birthDate.Year;
            if (birthDate.Date > today.AddYears(-age)) age--;

            // Corregir el acceso a Insurance
            var insuranceProp = patient.GetType().GetProperty("Insurance");
            var insurance = insuranceProp != null ? insuranceProp.GetValue(patient) : null;
            bool hasInsurance = insurance != null;

            // Acceso seguro a IsActive y EndDate
            bool policyActive = false;
            DateTime policyEndDate = DateTime.MinValue;
            if (hasInsurance)
            {
                var isActiveProp = insurance.GetType().GetProperty("IsActive");
                policyActive = isActiveProp != null && (bool)isActiveProp.GetValue(insurance);

                var endDateProp = insurance.GetType().GetProperty("EndDate");
                policyEndDate = endDateProp != null ? ((DateTime)endDateProp.GetValue(insurance)).Date : DateTime.MinValue;
            }
            int daysOfValidity = hasInsurance
                ? (policyEndDate - today.Date).Days
                : 0;

            // 2. Traer información clínica de las órdenes (detalle para la factura)
            var allDetails = new List<InvoiceDetails>();

            foreach (var orderNumber in orderNumbers)
            {
                if (string.IsNullOrWhiteSpace(orderNumber))
                    continue;

                // Corregir: obtener detalles de orden usando reflexión si es necesario
                var getOrderDetailsMethod = orderPort.GetType().GetMethod("GetOrderDetails");
                if (getOrderDetailsMethod == null)
                    throw new InvalidOperationException("No se puede obtener detalles de la orden.");

                var orderDetails = getOrderDetailsMethod.Invoke(orderPort, new object[] { orderNumber });
                if (orderDetails == null)
                    throw new InvalidOperationException($"No se encontraron datos para la orden {orderNumber}.");

                // Se asume que orderDetails.Medications, Procedures y Diagnostics son listas de objetos con propiedades Description y Cost
                var medicationsProp = orderDetails.GetType().GetProperty("Medications");
                var medications = medicationsProp != null ? medicationsProp.GetValue(orderDetails) as IEnumerable<object> : null;
                if (medications != null)
                {
                    foreach (var med in medications)
                    {
                        var descProp = med.GetType().GetProperty("Description");
                        var costProp = med.GetType().GetProperty("Cost");
                        allDetails.Add(new InvoiceDetails
                        {
                            Description = descProp != null ? descProp.GetValue(med)?.ToString() : "",
                            Value = costProp != null ? Convert.ToDecimal(costProp.GetValue(med)) : 0m,
                            Type = "Medicamento"
                        });
                    }
                }

                var proceduresProp = orderDetails.GetType().GetProperty("Procedures");
                var procedures = proceduresProp != null ? proceduresProp.GetValue(orderDetails) as IEnumerable<object> : null;
                if (procedures != null)
                {
                    foreach (var proc in procedures)
                    {
                        var descProp = proc.GetType().GetProperty("Description");
                        var costProp = proc.GetType().GetProperty("Cost");
                        allDetails.Add(new InvoiceDetails
                        {
                            Description = descProp != null ? descProp.GetValue(proc)?.ToString() : "",
                            Value = costProp != null ? Convert.ToDecimal(costProp.GetValue(proc)) : 0m,
                            Type = "Procedimiento"
                        });
                    }
                }

                var diagnosticsProp = orderDetails.GetType().GetProperty("Diagnostics");
                var diagnostics = diagnosticsProp != null ? diagnosticsProp.GetValue(orderDetails) as IEnumerable<object> : null;
                if (diagnostics != null)
                {
                    foreach (var diag in diagnostics)
                    {
                        var descProp = diag.GetType().GetProperty("Description");
                        var costProp = diag.GetType().GetProperty("Cost");
                        allDetails.Add(new InvoiceDetails
                        {
                            Description = descProp != null ? descProp.GetValue(diag)?.ToString() : "",
                            Value = costProp != null ? Convert.ToDecimal(costProp.GetValue(diag)) : 0m,
                            Type = "Diagnóstico"
                        });
                    }
                }
            }

            // 3. Calcular total clínico (suma de todos los costos)
            decimal totalClinical = allDetails.Sum(d => d.Value);

            if (totalClinical <= 0)
                throw new InvalidOperationException("El valor total de la factura debe ser mayor que cero.");

            // 4. Reglas de copago
            decimal copay;
            if (!policyActive)
            {
                copay = totalClinical;
            }
            else if (accumulatedCopayYear >= 1_000_000m)
            {
                copay = 0m;
            }
            else
            {
                copay = Math.Min(50_000m, totalClinical);
            }

            decimal insuranceAmount = hasInsurance ? totalClinical - copay : 0m;
            if (insuranceAmount < 0) insuranceAmount = 0;

            // 5. Construir la factura con la información requerida
            var idProp = patient.GetType().GetProperty("Id");
            var patientIdValue = idProp != null ? idProp.GetValue(patient)?.ToString() : "";

            var invoice = new Invoice
            {
                PatientID = patientIdValue,
                IssueDate = DateTime.Now,
                Total = totalClinical,
                Copayment = copay,
                Status = "Emitida",
                Details = allDetails
            };

            // 6. Guardar la factura y devolverla
            Invoice.Save(invoice);

            return invoice;
        }
        public void UpdateEmployee(Employee employee, string newEmail, string newPhone, string newAddress, string newRole) { /* ... */ }
        public void DeactivateEmployee(string documentNumber) { /* ... */ }
        public void ResetPassword(string userName, string newPassword) { /* ... */ }
        public static Employee FindByUserName(string userName)
        {
        
            return null;
        }
        public IEnumerable<Employee> SearchEmployees(string filter)
        {
           
            return Enumerable.Empty<Employee>();
        }
    }
    
}
