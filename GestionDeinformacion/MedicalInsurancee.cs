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
            CompanyInsurance = companyInsurance;
            PolicyNumber = policyNumber;
            PolicyStatus = policyStatus;
            PolicyValidity = policyValidity;
        }

        
    }
}
