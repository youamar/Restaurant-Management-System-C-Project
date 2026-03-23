using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class
{
    public class RoleModel
    {
        public string role_id { get; set; }
        public string role_password { get; set; }
        public string role { get; set; }
        public string role_name { get; set; }
        public string role_ic { get; set; }
        public string role_contact { get; set; }
        public string role_email { get; set; }
        public int role_status { get; set; }

        public decimal chef_revenue {  get; set; }

    }
}
