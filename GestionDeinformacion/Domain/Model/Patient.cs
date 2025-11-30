using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeinformacion.Domain.Model
{
    internal class Patient
    {
        public string Id { get; set; }          // Cédula
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }      // "M", "F", "O"
        public string Address { get; set; }
        public string Phone { get; set; }       // 10 dígitos
        public string Email { get; set; }       // Opcional
        public EmergencyContact Emergency { get; set; }
        public MedicalInsurance Insurance { get; set; }
        internal object FindByDocument(object patientDocument)
        {
            throw new NotImplementedException();
        }


    }
}
