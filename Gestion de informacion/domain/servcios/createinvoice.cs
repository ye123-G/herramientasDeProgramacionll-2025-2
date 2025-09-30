using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_de_informacion.domain.servcios
{
    internal class createinvoice
    {
        public void CreateInvoice(Invoice invoice)
        {
            if (string.IsNullOrEmpty(invoice.Product) || invoice.Price <= 0)
            {
                throw new Exception("No se puede generar factura, datos invalidos.");
            }

            invoicePort.Save(invoice);
        }
    }
}
