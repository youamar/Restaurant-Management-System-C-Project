using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Class
{
    internal class InvoiceService
    {
        private readonly InvoiceRepository _invoiceRepository;

        public InvoiceService(string connectionString)
        {
            _invoiceRepository = new InvoiceRepository(connectionString);
        }

        public List<InvoiceModel> GetInvoiceByID(string customer_id)
        {
            return _invoiceRepository.GetInvoiceByID(customer_id);
        }

        public bool AddInvoice(string invoice_id, string order_id, decimal amount, string invoice_status)
        {
            var invoiceModels = new InvoiceModel {
                invoice_id = invoice_id,
                order_id = order_id,
                amount = amount,
                invoice_status = invoice_status
            };
            return _invoiceRepository.AddInvoice(invoiceModels);
        }

        public bool UpdateInvoiceStatus(string order_id, string invoice_status)
        {
            return _invoiceRepository.UpdateInvoice(order_id, invoice_status);
        }

        public decimal GetRevenueByMonth(DateTime date)
        {
            return _invoiceRepository.GetRevenueByMonth(date);
        }
    }

}
