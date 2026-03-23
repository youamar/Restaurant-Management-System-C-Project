using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Main_Page.Role;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Main_Page
{
    public partial class Role_Profile : Form
    {
        public Role_Profile()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

            Role_Profile_Control _Profile_Control = new Role_Profile_Control(lid, lcontact, lemail, lid, lbltitle);
            _Profile_Control.Profile();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Role_EditProfile edit = new Role_EditProfile();
            edit.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Role_ChangePassword changepass = new Role_ChangePassword();
            changepass.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
