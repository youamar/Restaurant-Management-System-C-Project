using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Assignmemt_inventory;

namespace Main_Page.Reservation
{
    public partial class HallDisplay : Form
    {
        private HallDisplayControl _halldisplayControl;

        private Button[] buttons;

        public HallDisplay()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

            Description.Parent = pictureBox;

            buttons = new Button[] {h1, h2, h3, h4, h5, h6};
            HallDisplayControl _halldisplayControl = new HallDisplayControl(this, buttons, Description, pictureBox);
            _halldisplayControl.LoadData();

        }

        private void label5_Click(object sender, EventArgs e)
        {
            HallDisplay obj1 = new HallDisplay();
            obj1.Show();
            this.Hide();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            Home obj1 = new Home();
            obj1.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Menu obj1 = new Menu();
            obj1.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Booking obj1 = new Booking();
            obj1.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            AboutUs obj1 = new AboutUs();
            obj1.Show();
            this.Hide();
        }

        private void btnbook_Click(object sender, EventArgs e)
        {
            NewReservation obj1 = new NewReservation();
            obj1.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            CustomerProfile obj1 = new CustomerProfile();
            obj1.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MailBox obj1 = new MailBox();
            obj1.Show();
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
