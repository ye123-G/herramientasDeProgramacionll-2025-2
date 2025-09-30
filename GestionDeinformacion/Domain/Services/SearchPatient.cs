namespace GestionDeinformacion.Domain.Services
{
    internal class SearchPatient : Patient
    {
        private readonly IPatientPort patientPort;


        public Patient FindPatientById(string patientId)
        {
            Patient patient = patientPort.FindById(patientId);

            if (patient == null)
            {
                throw new Exception("No se encontro paciente con esa identificacion.");
            }

            return patient;
        }
    }
}

public class Patient
{
    public object Document { get; internal set; }

    internal object FindByDocument(object patientDocument)
    {
        
        return null;
    }
}

