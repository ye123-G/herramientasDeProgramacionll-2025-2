using GestionDeinformacion.Domain.Model;
using GestionDeinformacion.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeinformacion.application.usercases
{
    internal class Administrativestaff
    {
        private readonly CreatePatient createPatient;
        private readonly CreateAppointment createAppointment; // Fix: Corrected the casing to match the field name
        private readonly CreateInvoice createInvoice;
        private readonly UpdatePatient updatePatient;

        public Administrativestaff(
            CreatePatient createPatient,
            CreateAppointment createAppointment,
            CreateInvoice createInvoice,
            UpdatePatient updatePatient)
        {
            this.createPatient = createPatient;
            this.createAppointment = createAppointment; // Fix: Corrected the casing to match the field name
            this.createInvoice = createInvoice;
            this.updatePatient = updatePatient;
        }

        public void CreatePatient(Patient patient)
        {
            createPatient.Create(patient);
        }

        // Programar cita para un paciente con un médico
        public void CreateAppointment(
            string appointmentId,
            string patientId,
            string doctorId,
            DateTime date,
            string reason)
        {
            var appointment = new Appointment
            {
                Id = appointmentId,
                PatientId = patientId,
                DoctorId = doctorId,
                Date = date,
                Reason = reason
            };

            createAppointment.Execute(appointment); // Fix: Corrected the field name to match the constructor parameter
        }

        // Generar factura aplicando reglas de póliza y copago
        public Invoice CreateInvoice(
            string patientId,
            string doctorName,
            IList<string> orderNumbers,
            decimal accumulatedCopayYear)
        {
            return createInvoice.Execute(
                patientId,
                doctorName,
                orderNumbers,
                accumulatedCopayYear);
        }

        // Actualizar datos básicos del paciente
        public void UpdatePatient(Patient patient)
        {
            updatePatient.Execute(patient);
        }

        // Métodos que NO debe gestionar el personal administrativo
        // se dejan privados o se eliminan:

        private void CreateMedicalRecord()
        {
            // Solo médicos
            throw new InvalidOperationException(
                "El personal administrativo no puede gestionar la historia clínica.");
        }

        private void CreateOrder()
        {
            // Solo médicos
            throw new InvalidOperationException(
                "El personal administrativo no puede crear órdenes médicas.");
        }

        private void CreateVisit()
        {
            // Solo enfermería
            throw new InvalidOperationException(
                "El personal administrativo no puede registrar visitas de enfermería.");
        }
    }
}

