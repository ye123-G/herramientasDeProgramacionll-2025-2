using GestionDeinformacion.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeinformacion.Domain.Services
{
    internal class CreateVisit
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
            else
            {
                visitPort.Save(visit);
            }
        }
    }

    internal class VisitPort
    {
        internal void Save(Visit visit)
        {
            throw new NotImplementedException();
        }
    }
}
