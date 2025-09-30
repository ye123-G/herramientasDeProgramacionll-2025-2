using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeinformacion.Domain.Model
{
    internal class Appointment
    {
        private ulong patientID; 
        private ulong doctorID; 
        private DateTime dateTime; 
        private string status;

        public ulong PatientID { get => patientID; set => patientID = value; }
        public ulong DoctorID { get => doctorID; set => doctorID = value; }
        public DateTime DateTime { get => dateTime; set => dateTime = value; }
        public string Status { get => status; set => status = value; }
        public object PatientDocument { get; internal set; }

        internal void Save(Appointment appointment)
        {
            throw new NotImplementedException();
        }
    }
}
