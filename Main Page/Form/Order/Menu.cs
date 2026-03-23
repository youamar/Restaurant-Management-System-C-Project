using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AssingnemntNote;
using Main_Page.Order;
using Main_Page.Reservation;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Main_Page
{
    public partial class Menu : Form
    {
        private MenuControl _menuControl;

        public Menu()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

            Button[] buttonsC = { c1, c2, c3, c4, c5, c6, c7, c8, c9, c10 };
            Button[] buttonsF = { f1, f2, f3, f4, f5, f6, f7, f8, f9, f10, f11, f12, f13, f14, f15 };
            Label[] labelsD = { d1, d2, d3, d4, d5, d6, d7, d8, d9, d10, d11, d12, d13, d14, d15 };
            
            _menuControl = new MenuControl(this, buttonsC, buttonsF, labelsD);
            _menuControl.LoadData();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            Home obj1 = new Home();
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
            if (CartControl.Instance.EmptyCart())
            {
                MessageBox.Show("Your Cart is Empty!");
                return;
            }

            Cart obj1 = new Cart();
            this.Hide();
            obj1.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            CustomerProfile obj1 = new CustomerProfile();
            obj1.Show();
            this.Hide();
        }

        private void ViewStatus_Click(object sender, EventArgs e)
        {
            OrderStatus obj1 = new OrderStatus();
            obj1.Show();
        }
    }
}
