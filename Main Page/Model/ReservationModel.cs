using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOOP
{
    internal class ReservationModel
    {
        public string reservation_id {  get; set; }
        public string customer_id {  get; set; }
        public string date {  get; set; }
        public string time { get; set; }
        public string pax { get; set; }
        public string request { get; set; }
        public string status { get; set; }
        public string hall_id { get; set; }
        public string role_id { get; set; }
    }
}
