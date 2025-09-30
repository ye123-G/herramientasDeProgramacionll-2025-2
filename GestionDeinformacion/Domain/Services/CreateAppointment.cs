using GestionDeinformacion.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeinformacion.Domain.Services
{
    internal class CreateAppointment
    {
        private readonly Patient patientPort;
        private readonly Appointment appointmentPort;

        public CreateAppointment(Patient patientPort, Appointment appointmentPort)
        {
            this.patientPort = patientPort;
            this.appointmentPort = appointmentPort;
        }

        public void Create(Appointment appointment)
        {
            var patient = patientPort.FindByDocument(appointment.PatientDocument);
            if (patient == null)
            {
                throw new Exception("Paciente no registrado");
            }
            appointmentPort.Save(appointment);
        }
    }
}
