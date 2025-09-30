using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeinformacion.Domain.Model
{
    internal class MedicalInsurance
    {
        private string companyInsurance;
        private string policyNumber;
        private bool policyStatus;  
        private DateTime policyValidity;

        public string CompanyInsurance { get => companyInsurance; set => companyInsurance = value; }
        public string PolicyNumber { get => policyNumber; set => policyNumber = value; }
        public bool PolicyStatus { get => policyStatus; set => policyStatus = value; }
        public DateTime PolicyValidity { get => policyValidity; set => policyValidity = value; }
    }
}
