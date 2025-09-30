using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gestion_de_informacion.domain.ports; // Asegúrate de que los puertos estén en este namespace
using Gestion_de_informacion.domain.models; // Asegúrate de que Appointment esté en este namespace

namespace Gestion_de_informacion.domain.servcios
{
    internal class CreateAppointment
    {
        private readonly Patient patientPort;
        private readonly Appointment appointmentPort;

        public CreateAppointment(Patient patientPort, AppointmentPort appointmentPort)
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
