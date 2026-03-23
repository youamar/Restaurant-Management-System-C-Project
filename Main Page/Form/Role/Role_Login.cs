using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main_Page
{
    public partial class Role_Login : Form
    {
        public Role_Login()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Role_Login_Control login = new Role_Login_Control(tbid.Text, tbPass.Text, this);
            login.CheckStaff();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Customer_Login obj1 = new Customer_Login();
            obj1.Show();
            this.Hide(); 
        }
    }
}
