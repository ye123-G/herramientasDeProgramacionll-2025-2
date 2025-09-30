using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeinformacion.Domain.Model
{
    internal class Visit
    {
        internal object PatientId;
        private ulong patientID;
        private ulong nurseID; 
        private DateTime dateTime; 
        private string visitType;

        public ulong PatientID { get => patientID; set => patientID = value; }
        public ulong NurseID { get => nurseID; set => nurseID = value; }
        public DateTime DateTime { get => dateTime; set => dateTime = value; }
        public string VisitType { get => visitType; set => visitType = value; }
    }
}
