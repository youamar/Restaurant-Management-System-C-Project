using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssingnemntNote
{
    public class MenuModel
    {
        public int item_id { get; set; }
        public string item { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public string category_id { get; set; }
        public int is_active {  get; set; }
        public byte[] photo {  get; set; }

    }
}
