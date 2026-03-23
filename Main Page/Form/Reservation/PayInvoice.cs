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
    public partial class PayInvoice : Form
    {

        public event Action PaymentCompleted;
        public event Action PaymentCancelled;

        public PayInvoice()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtname.Text == "" || txtcard.Text == "" || txtdate.Text == " MM/YY" || txtcode.Text == " CCV")
            {
                MessageBox.Show("Please Full Fill Your Details");
            }
            else
            {
                MessageBox.Show("Payment Successful!");

                PaymentCompleted?.Invoke();
                this.Close();
            }
        }
    }
}
