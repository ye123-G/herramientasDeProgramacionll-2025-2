using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_informacion.domain.servcios
{
    internal class createvisit
    {
        private readonly PatientPort patientPort;
        private readonly VisitPort visitPort;

        public CreateVisit(PatientPort patientPort, VisitPort visitPort)
        {
            this.patientPort = patientPort;
            this.visitPort = visitPort;
        }

        public void Create(Visit visit)
        {
            if (patientPort.FindById(visit.PatientId) == null)
            {
                throw new Exception("Paciente no encontrado.");
            }

            visitPort.Save(visit);
        }
    }
}
