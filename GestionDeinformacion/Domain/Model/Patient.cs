using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeinformacion.Domain.Model
{
    internal class Patient
    {
        private long emergencycontact;
        private long healthinsurance;

        public string Gender { get; set; }
        public long Emergencycontact { get => emergencycontact; set => emergencycontact = value; }
        public long Healthinsurance { get => healthinsurance; set => healthinsurance = value; }

        internal object FindByDocument(object patientDocument)
        {
            throw new NotImplementedException();
        }
    }
}
