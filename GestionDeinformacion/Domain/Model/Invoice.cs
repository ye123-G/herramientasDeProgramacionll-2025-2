using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDeinformacion.Domain.Model
{
    internal class Invoice
    {
        private ulong id;
        private string patientID;
        private DateTime issueDate;
        private decimal total;
        private decimal copayment;
        private string status;
        private List<InvoiceDetails> details;

        public ulong Id { get => id; set => id = value; }
        public string PatientID { get => patientID; set => patientID = value; }
        public DateTime IssueDate { get => issueDate; set => issueDate = value; }
        public decimal Total { get => total; set => total = value; }
        public decimal Copayment { get => copayment; set => copayment = value; }
        public string Status { get => status; set => status = value; }
        public List<InvoiceDetails> Details { get => details; set => details = value; }
        public string? Product { get; internal set; }
        public int Price { get; internal set; }

        internal static void Save(Invoice invoice)
        {
            throw new NotImplementedException();
        }
    }
}
