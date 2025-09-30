using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_informacion.domain.servcios
{
    internal class updatemedicalrecord
    {
        private readonly MedicalRecordPort recordPort;

        public UpdateMedicalRecord(MedicalRecordPort recordPort)
        {
            this.recordPort = recordPort;
        }

        public void Update(MedicalRecord record)
        {
            var existing = recordPort.FindByPatientId(record.PatientId);

            if (existing == null)
            {
                throw new Exception("Registro medico no encontrado.");
            }

            recordPort.Update(record);
        }
    }
}
