using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeinformacion.Domain.Services
{
   
internal class updatePatient:Patient
    {
        private readonly PatientPort patientPort;

        public updatePatient(PatientPort patientPort)
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
    
        public interface PatientPort
        {
            object FindByDocument(object document);
            object FindById(object patientId);
            void Update(Patient patient);
        }
}
