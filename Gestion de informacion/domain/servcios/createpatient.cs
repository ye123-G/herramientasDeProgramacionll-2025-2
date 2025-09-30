using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_informacion.domain.servcios
{
    internal class createpatient
    {
        public void CreatePatient(Patient patient)
        {
            if (patientPort.FindByDocument(patient) != null)
            {
                throw new Exception("Error: el paciente ya existe, no se guardo.");
            }

            patientPort.Save(patient);
        }
        
    }
}
