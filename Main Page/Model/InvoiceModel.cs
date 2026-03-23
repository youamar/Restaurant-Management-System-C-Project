using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class
{
    internal class InvoiceModel
    {
        public string invoice_id { get; set; }
        public string order_id { get; set; }
        public decimal amount { get; set; }
        public string invoice_status { get; set; }
        public string date {  get; set; }
        
    }
}
