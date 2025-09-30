using GestionDeinformacion.Domain.Model;
using System;

namespace GestionDeinformacion.Domain.Services
{
    internal class SearchOrder
    {
        private readonly OrderPort orderPort;

        public SearchOrder(OrderPort orderPort)
        {
            this.orderPort = orderPort ?? throw new ArgumentNullException(nameof(orderPort));
        }

        public Order FindOrderByPatientId(string patientId)
        {
            Order order = orderPort.FindByPatientId(patientId);

            if (order == null)
            {
                throw new Exception("No se han encontrado registros para este paciente.");
            }

            return order;
        }
    }
    public class Order
    {
        public object PatientId { get; set; }
    }

    public interface OrderPort
    {
        Order FindByPatientId(string patientId);
        void Save(Order order);
    }
}
