using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_informacion.domain.servcios
{
    internal class searchorder
    {
        public Order SearchOrder(string patientId)
        {
            Order order = orderPort.FindByPatientId(patientId);

            if (order == null)
            {
                throw new Exception("No se han encontrado registros para este paciente.");
            }

            return order;
        }
    }
}
