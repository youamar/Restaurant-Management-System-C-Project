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
    public partial class NewReservation : Form
    {

        public NewReservation()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

            request.Text = "";
            btnnew.BackColor = Color.Coral;
            date.Value = DateTime.Now;

            NewReservationControl _newReservationControl = new NewReservationControl(hall);
            _newReservationControl.LoadHallData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (time.SelectedIndex == -1 || hall.SelectedIndex == -1 || pax.SelectedIndex == -1)
            {
                MessageBox.Show("Please Full Fill Your Details");
            }
            else
            {
                PayInvoice obj1 = new PayInvoice();

                obj1.PaymentCompleted += () =>
                {
                    NewReservationControl control = new NewReservationControl(date, time, pax, hall, request);
                    control.AddReservation();
                    MessageBox.Show("Reservation Added Successfully!");
                    control.ClearType(time, pax, hall, request);
                };

                obj1.Show();
            }
        }

        private void label1_Click(object sender, EventArgs e)
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

        private void label5_Click(object sender, EventArgs e)
        {
            HallDisplay obj1 = new HallDisplay();
            obj1.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            AboutUs obj1 = new AboutUs();
            obj1.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            NewReservation obj1 = new NewReservation();
            obj1.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Booking obj1 = new Booking();
            obj1.Show();
            this.Hide();
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            SessionManager.Instance.Logout();
            Customer_Login obj1 = new Customer_Login();
            obj1.Show();
            this.Hide();
        }
    }
}
