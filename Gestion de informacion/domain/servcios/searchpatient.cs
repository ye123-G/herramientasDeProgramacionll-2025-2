using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_informacion.domain.servcios
{
    internal class searchpatient
    {
        public Patient SearchPatient(string patientId)
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
