using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeinformacion.Domain.Model
{
    internal class InvoiceDetails
    {
        private string description; 
        private decimal value; 
        private string type; 

        public string Description { get => description; set => description = value; }
        public decimal Value { get => value; set => this.value = value; }
        public string Type { get => type; set => type = value; }
    }
}
