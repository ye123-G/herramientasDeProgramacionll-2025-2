

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeinformacion.Domain.Model
{
    internal class HumanResources
    {
        private string fullname;
        private string documentNumber;
        private string email;
        private string phoneNumber;
        private DateTime birthDate;
        private string address;
        private string role;
        public string Fullname { get => fullname; set => fullname = value; }
        public string DocumentNumber { get => documentNumber; set => documentNumber = value; }
        public string Email { get => email; set => email = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public DateTime BirthDate { get => birthDate; set => birthDate = value; }
        public string Address { get => address; set => address = value; }
        public string Role { get => role; set => role = value; } 
    }

}

