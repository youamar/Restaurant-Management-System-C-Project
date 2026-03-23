using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main_Page
{
    internal class SessionManager
    {
        private static SessionManager _instance;
        private static readonly object _lock = new object();

        public string CustomerId { get; set; }
        public string RoleId { get; set; } 

        private SessionManager() { }

        public static SessionManager Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new SessionManager();
                    }
                    return _instance;
                }
            }
        }

        public void Logout()
        {
            MessageBox.Show("Logout Sucessfully!");
            this.CustomerId = null;
            this.RoleId = null;
        }

    }
}
