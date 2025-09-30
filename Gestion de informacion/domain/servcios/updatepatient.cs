using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_informacion.domain.servcios
{
    internal class updatepatient
    {
        internal class UpdatePatient
        {
            private readonly PatientPort patientPort;

            public UpdatePatient(PatientPort patientPort)
            {
                this.patientPort = patientPort;
            }

            public void Update(Patient patient)
            {
                var existing = patientPort.FindByDocument(patient.Document);
                if (existing == null)
                {
                    throw new Exception("Paciente no encontrado");
                }
                patientPort.Update(patient);
            }
        }
    }
}

