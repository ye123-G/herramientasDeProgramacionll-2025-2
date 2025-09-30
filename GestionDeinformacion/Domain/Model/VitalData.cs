using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeinformacion.Domain.Model
{
    internal class VitalData
    {

        private ulong idVisit;
        private DateTime registrationdate; 
        private decimal bloodPressure; 
        private decimal temperature; 
        private int pulse; 
        private decimal oxygenBlood; 
        private string observations;

        public ulong IdVisit { get => idVisit; set => idVisit = value; }
        public DateTime Registrationdate { get => registrationdate; set => registrationdate = value; }
        public decimal BloodPressure { get => bloodPressure; set => bloodPressure = value; }
        public decimal Temperature { get => temperature; set => temperature = value; }
        public int Pulse { get => pulse; set => pulse = value; }
        public decimal OxygenBlood { get => oxygenBlood; set => oxygenBlood = value; }
        public string Observations { get => observations; set => observations = value; }
    }
}
