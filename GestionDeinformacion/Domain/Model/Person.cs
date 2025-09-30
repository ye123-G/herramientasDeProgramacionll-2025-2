using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeinformacion.Domain.Model
{
    internal class Person
    {
        private ulong id;
        private string _Fullname; 
        private long identitycard; 
        private DateTime dateOfBirth; 
        private long cellphone; 
        private string mail; 
        private string address; 

        public ulong Id { get => id; set => id = value; }
        public string Fullname { get => _Fullname; set => _Fullname = value; }
        public long Identitycard { get => identitycard; set => identitycard = value; }
        public DateTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
        public long Cellphone { get => cellphone; set => cellphone = value; }
        public string Mail { get => mail; set => mail = value; }
        public string Address { get => address; set => address = value; }
    }
}
