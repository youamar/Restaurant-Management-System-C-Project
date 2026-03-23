using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssingnemntNote
{
    internal class OrderDetailModel
    {
        public string detail_id { get; set; }
        public string order_id { get; set; }
        public int item_id { get; set; }
        public int quantity { get; set; }
        public string status { get; set; }
        public string role_id { get; set; }

    }
}
