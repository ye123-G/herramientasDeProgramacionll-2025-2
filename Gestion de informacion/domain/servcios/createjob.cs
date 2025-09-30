using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_informacion.domain.servcios
{
    internal class createjob

    {
        private readonly EmployeePort employeePort;

        public UpdateEmployee(EmployeePort employeePort)
        {
            this.employeePort = employeePort;
        }

        public void Update(Employee employee)
        {
            var existing = employeePort.FindByDocument(employee.Document);
            if (existing == null)
            {
                throw new Exception("Empleado no encontrado");
            }
            employeePort.Update(employee);
        }
    }
}
