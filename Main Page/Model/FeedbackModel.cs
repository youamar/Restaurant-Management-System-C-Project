using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignmemt_inventory
{
    internal class FeedbackModel
    {
        public string feedback_id { get; set; }
        public int rating { get; set; }
        public string content { get; set; }
        public string order_id { get; set; }
        public string date { get; set; }
    }
}
