using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssingnemntNote
{
    internal class OrderModel
    {

        public string order_id { get; set; }
        public int table_number { get; set; }
        public string customer_id { get; set; }
        public List<OrderDetailModel> orderdetail { get; set; }

    }
}
