using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignmemt_inventory
{
    public class HallModel
    {
        public string hall_id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int maxcapacity { get; set; }
        public string type { get; set; }
        public string restaurant_id { get; set; }
        public int is_active { get; set; }
        public byte[] photo { get; set; }
    }
}
