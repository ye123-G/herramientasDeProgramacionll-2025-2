using GestionDeinformacion.Domain.Model;
using System;


namespace GestionDeinformacion.Domain.Services
{
    internal class CreatePatient
    {
        private readonly IPatientPort patientPort;

        public CreatePatient(IPatientPort patientPort)
        {
            this.patientPort = patientPort;
        }
        internal interface IPatientPort
        {
            object FindById(object patientId);
            object FindByDocument(object patientDocument); 
            void Save(Patient patient); 
        }
        public void Create(Patient patient)

        {

            if (patientPort.FindByDocument(patient.Document) != null)
            {
                throw new Exception("Error: el paciente ya existe, no se guardó.");
            }

            patientPort.Save(patient);
        }
    }
}
