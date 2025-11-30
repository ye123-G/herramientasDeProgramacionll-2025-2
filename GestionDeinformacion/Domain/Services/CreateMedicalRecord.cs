using GestionDeinformacion.Domain.Model;
using Microsoft.Graph;
using System;

namespace GestionDeinformacion.Domain.Services
{
    internal class CreateMedicalRecord
    {
        private PatientPort patientPort;
        private MedicalRecordPort recordPort;
        private string? patientId;

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
            if (string.IsNullOrWhiteSpace(patientId))
            {
                throw new ArgumentException("La cédula del paciente es obligatoria.");
            }

            recordPort.Save(record); 
        }
    }


    public interface MedicalRecordPort 
    {
        void Save(MedicalRecord record);
    }
}
