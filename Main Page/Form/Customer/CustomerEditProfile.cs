using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Main_Page.Reservation;

namespace Main_Page
{
    public partial class CustomerEditProfile : Form
    {
        private CustomerEditProfileControl control;

        public CustomerEditProfile()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

            control = new CustomerEditProfileControl(this, tbname, tbcontact, tbemail, date);
            control.LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            control.Update(tbname.Text, tbcontact.Text, tbemail.Text, date.Value.ToString("dd/MM/yyyy"));
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            CustomerProfile obj1 = new CustomerProfile();
            obj1.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            AboutUs obj1 = new AboutUs();
            obj1.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            HallDisplay obj1 = new HallDisplay();
            obj1.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Booking obj1 = new Booking();
            obj1.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Menu obj1 = new Menu();
            obj1.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Home obj1 = new Home();
            obj1.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            SessionManager.Instance.Logout();
            Customer_Login obj1 = new Customer_Login();
            obj1.Show();
            this.Hide();
        }
    }
}
