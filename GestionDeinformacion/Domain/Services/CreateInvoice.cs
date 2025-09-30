using GestionDeinformacion.Domain.Model;

namespace GestionDeinformacion.Domain.Services
{
    internal class CreateInvoice
    {

        public void createInvoice(Invoice invoice)
        {
            if (string.IsNullOrEmpty(invoice.Product) || invoice.Price <= 0)
            {
                throw new Exception("No se puede generar factura, datos invalidos.");
            }


            Invoice.Save(invoice);
        }
    }
}
