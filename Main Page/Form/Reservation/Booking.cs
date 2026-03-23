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
    public partial class Booking : Form
    {
        private GroupBox[] boxs;
        private Label[] dates;
        private Label[] times;
        private Label[] paxs;
        private Label[] halls;
        private Label[] labels;
        private Label[] requests;
        private Label[] status;

        public Booking()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

            btnbooking.BackColor = Color.Coral;

            boxs = new GroupBox[] { box1, box2, box3, box4, box5 };
            dates = new Label[] { date1, date2, date3, date4, date5 };
            times = new Label[] { time1, time2, time3, time4, time5 };
            paxs = new Label[] { pax1, pax2, pax3, pax4, pax5 };
            halls = new Label[] { hall1, hall2, hall3, hall4, hall5 };
            labels = new Label[] { lbl1, lbl2, lbl3, lbl4 , lbl5 };
            requests = new Label[] { request1,  request2, request3, request4, request5 };
            status = new Label[] { status1, status2, status3, status4, status5 };

            BookingControl _bookingControl = new BookingControl(this, boxs, dates, times, paxs, halls, labels, requests, status);
            _bookingControl.LoadData();
            _bookingControl.CheckData();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Home obj1 = new Home();
            obj1.Show();
            this.Hide();
        }

        private void c3_Click(object sender, EventArgs e)
        {
            NewReservation obj1 = new NewReservation();
            obj1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
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
