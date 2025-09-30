using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeinformacion.Domain.Model
{
    internal class Nurse
    {
        private ulong orderNumber;
        private string patientId;
        private string doctorId;
        private DateTime creationDate;
        private string type;

        public ulong OrderNumber { get => orderNumber; set => orderNumber = value; }
        public string PatientId { get => patientId; set => patientId = value; }
        public string DoctorId { get => doctorId; set => doctorId = value; }
        public DateTime CreationDate { get => creationDate; set => creationDate = value; }
        public string Type { get => type; set => type = value; }
    }
}
