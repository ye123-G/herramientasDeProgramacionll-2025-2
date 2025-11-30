using GestionDeinformacion.Domain.ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeinformacion.Domain.Services
{
    internal class UpdateRegistr(IPatientPort patientPort)
    {
        private readonly IPatientPort patientPort = patientPort;

        public void Update(Patient patient)
        {
            var existing = patientPort.FindByDocument(patient.Document);
            if (existing == null)
            {
                throw new Exception("Paciente no encontrado");
            }
            patientPort.Update(patient);
        }    
}   }
