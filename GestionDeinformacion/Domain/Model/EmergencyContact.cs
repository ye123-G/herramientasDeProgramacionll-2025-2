using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeinformacion.Domain.Model
{
    internal class EmergencyContact
    {
        private string fullname; 
        private string relationship; 
        private long cellphone;
        private string Email;

        private long Email { get; set; }
        public string Fullname { get => fullname; set => fullname = value; }
        public string Relationship { get => relationship; set => relationship = value; }
        public long Cellphone { get => cellphone; set => cellphone = value; }
    }
}
