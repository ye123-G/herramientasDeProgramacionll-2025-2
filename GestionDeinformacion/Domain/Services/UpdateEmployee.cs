using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeinformacion.Domain.Services
{
    internal class UpdateEmployee
    {
        private IEmployeePort employeePort;

        public UpdateEmployee(IEmployeePort employeePort) 
        {
            this.employeePort = employeePort;
        }

        public void updateEmployee(Employee employee)
        {
            if (employeePort.FindByDocument(employee) == null)
            {
                employeePort.Save(employee);
            }
            else
            {
                throw new Exception("Error: el empleado ya existe, no se guardo.");
            }
        }
    }

    public interface IEmployeePort
    {
        Employee FindByDocument(Employee employee);
        void Save(Employee employee);
    }
}
