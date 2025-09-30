using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_informacion.domain.servcios
{
    internal class createorder
    {
        private readonly PatientPort patientPort;
        private readonly OrderPort orderPort;

        public CreateOrder(PatientPort patientPort, OrderPort orderPort)
        {
            this.patientPort = patientPort;
            this.orderPort = orderPort;
        }

        public void Create(Order order)
        {
            if (patientPort.FindById(order.PatientId) == null)
            {
                throw new Exception("Paciente no encontrado.");
            }

            orderPort.Save(order);
        }
    }
}
