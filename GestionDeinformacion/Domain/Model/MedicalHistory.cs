using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeinformacion.Domain.Model
{
    internal class MedicalHistory
    {
        private string patientID; 
        private Dictionary<string, Dictionary<string, object>> records; 

        public string PatientID { get => patientID; set => patientID = value; }
        public Dictionary<string, Dictionary<string, object>> Records { get => records; set => records = value; }
        public MedicalHistory()
        {
            records = new Dictionary<string, Dictionary<string, object>>();
        }
    }
}
