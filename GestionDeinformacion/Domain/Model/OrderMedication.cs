using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeinformacion.Domain.Model
{
    internal class OrderMedication
    {
        private int orderNumber;
        private long idMedication;
        private double dose;
        private DateTime durationTreatment;
        private int item;

        public OrderMedication() { }

        public int OrderNumber { get => orderNumber; set => orderNumber = value; }
        public long IdMedication { get => idMedication; set => idMedication = value; }
        public double Dose { get => dose; set => dose = value; }
        public DateTime DurationTreatment { get => durationTreatment; set => durationTreatment = value; }
        public int Item { get => item; set => item = value; }
    }
}
