using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Main_Page.Reservation;

namespace Main_Page
{
    public partial class CustomerProfile : Form
    {
        public CustomerProfile()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

            CustomerProfileControl control = new CustomerProfileControl(lblname, lblcontact, lblemail, lblbirthday);
            control.LoadData();
        }

        public CustomerProfile(string customer_id)
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.Visible = true;
            panel1.Visible = false;
            lblUpdate.Visible = false;
            lblreturn.Visible = true;

            CustomerProfileControl control = new CustomerProfileControl(customer_id, lblname, lblcontact, lblemail, lblbirthday);
            control.LoadCustomerData();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MailBox obj1 = new MailBox();
            obj1.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            CustomerProfile obj1 = new CustomerProfile();
            obj1.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Home obj1 = new Home();
            obj1.Show();
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Menu obj1 = new Menu();
            obj1.Show();
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Booking obj1 = new Booking();
            obj1.Show();
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            HallDisplay obj1 = new HallDisplay();
            obj1.Show();
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            AboutUs obj1 = new AboutUs();
            obj1.Show();
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            CustomerEditProfile obj1 = new CustomerEditProfile();
            obj1.Show();
            this.Close();
        }

        private void lblreturn_Click(object sender, EventArgs e)
        {
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
