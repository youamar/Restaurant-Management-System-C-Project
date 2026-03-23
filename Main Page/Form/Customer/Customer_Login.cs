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
    public partial class Customer_Login : Form
    {
        public Customer_Login()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Customer_Login_Control control = new Customer_Login_Control(this, contact.Text);
            control.Checkmember();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Customer_Signup signup = new Customer_Signup();
            signup.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Role_Login role = new Role_Login();
            role.Show();
            this.Hide();
        }
    }
}
