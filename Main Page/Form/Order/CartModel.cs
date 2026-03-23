using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssingnemntNote;

namespace Main_Page
{
    internal class CartModel
    {
        public MenuModel Item { get; set; }

        public int item_id {  get; set; }
        public string item_name { get; set; }
        public int quantity { get; set; }
        public decimal item_total_price { get; set; }
        public decimal sub_total_price { get; set; }
        public decimal service_change {  get; set; }
        public decimal sst {  get; set; }
        public decimal grand_total {  get; set; }

        public override string ToString()
        {
            return $"{item_name} x{quantity} - ${item_total_price}";
        }
    }
}
