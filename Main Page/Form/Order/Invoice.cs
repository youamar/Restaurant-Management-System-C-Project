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
    public partial class Invoice : Form
    {

        private InvoiceControl _invoiceControl;
        private Button[] buttons;
        private ListView listView;

        public Invoice()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

            buttons = new Button[] { I1, I2, I3, I4, I5, I6, I7 };
            listView = list;

            _invoiceControl = new InvoiceControl(buttons, listView);
            _invoiceControl.LoadData();
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
    }
}
