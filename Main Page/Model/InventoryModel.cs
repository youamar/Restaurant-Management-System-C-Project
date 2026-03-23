using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOOP
{
    public class InventoryModel
    {
        public string ingredient_id {  get; set; }
        public string ingredient_name { get; set; }
        public double stock {  get; set; }
        public double safety_stock { get; set; }
    }
}
