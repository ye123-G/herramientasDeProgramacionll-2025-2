using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_informacion.domain.servcios
{
    internal class updateemployee
    {
        public void UpdateEmployee(Employee employee)
        {
            if (employeePort.FindByDocument(employee) != null)
            {
                throw new Exception("Error: el empleado ya existe, no se guardo.");
            }

            employeePort.Save(employee);
        }
    }
}
