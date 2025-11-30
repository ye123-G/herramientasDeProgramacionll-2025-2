using System;

namespace GestionDeInformacion.Domain.Model
{
    public class MedicalInsurance
    {
        private string _companyInsurance;
        private string _policyNumber;
        private bool _policyStatus;  
        private DateTime _policyValidity;

        public MedicalInsurance(string companyInsurance, string policyNumber, bool policyStatus, DateTime policyValidity)
        {
            _companyInsurance = companyInsurance;
            _policyNumber = policyNumber;
            _policyStatus = policyStatus;
            _policyValidity = policyValidity;
        }

        public string CompanyInsurance
        {
            get => _companyInsurance;
            set => _companyInsurance = value;
        }

        public string PolicyNumber
        {
            get => _policyNumber;
            set => _policyNumber = value;
        }

        public bool PolicyStatus
        {
            get => _policyStatus;
            set => _policyStatus = value;
        }

        public DateTime PolicyValidity
        {
            get => _policyValidity;
            set => _policyValidity = value;
        }
    }
}
