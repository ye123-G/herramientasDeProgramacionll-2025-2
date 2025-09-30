using System;

namespace GestionDeinformacion.Domain.Services
{
    internal class CreateMedicalRecord
    {
        private PatientPort patientPort;
        private MedicalRecordPort recordPort;

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


    public interface MedicalRecordPort 
    {
        void Save(MedicalRecord record);
    }
}
