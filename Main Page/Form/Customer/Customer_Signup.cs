using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Main_Page.Control;

namespace Main_Page
{
    public partial class Customer_Signup : Form
    {
        public Customer_Signup()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!check.Checked)
            {
                MessageBox.Show("Agree policies to continue!");
            }
            else
            {
                Customer_Signup_Control control = new Customer_Signup_Control(this, contact.Text);
                control.Checkmember();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Customer_Login login = new Customer_Login();
            login.Show();
            this.Close();
        }
    }
}
