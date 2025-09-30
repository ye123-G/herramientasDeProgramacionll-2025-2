using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_informacion.domain.servcios
{
    internal class createmedicalrecord
    {
        public CreateMedicalRecord(PatientPort patientPort, MedicalRecordPort recordPort)
        {
            this.patientPort = patientPort;
            this.recordPort = recordPort;
        }

        public void Create(MedicalRecord record)
        {
            if (patientPort.FindById(record.PatientId) == null)
            {
                throw new Exception("Error: no se puede crear registro medico, paciente no encontrado.");
            }

            recordPort.Save(record);
        }
    }
}
