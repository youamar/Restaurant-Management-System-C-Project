using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

namespace Main_Page.Order
{
    public partial class Cart : Form
    {
        private readonly CartControl _cartControl;

        public Cart()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

            _cartControl = CartControl.Instance;
            LoadCartData();
        }

        private void LoadCartData()
        {
            OrderDetails.Items.Clear();
            foreach (var item in _cartControl.GetCart())
            {
                OrderDetails.Items.Add(item);
            }
            foreach (var item in _cartControl.DisplayPrices())
            {
                OrderDetails.Items.Add(item);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (OrderDetails.SelectedItem is CartModel selectedItem)
            {
                CartControl.Instance.IncreaseQuantity(selectedItem.item_id);
                RefreshCart();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (OrderDetails.SelectedItem is CartModel selectedItem)
            {
                CartControl.Instance.DecreaseQuantity(selectedItem.item_id);
                RefreshCart();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (OrderDetails.SelectedItem is CartModel selectedItem)
            {
                CartControl.Instance.RemoveItem(selectedItem.item_id);
                RefreshCart();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            _cartControl.GenerateOrderAndInvoice();

            MessageBox.Show(_cartControl.TotalPaid());
            MessageBox.Show("Your Orders have been submited.");

            Feedback obj1 = new Feedback(_cartControl.OrderID());
            obj1.TopMost = true;
            obj1.Show();
            
            Menu obj2 = new Menu();
            obj2.Show();

            this.Hide();
        }

        private void RefreshCart()
        {
            OrderDetails.Items.Clear();
            foreach (var item in _cartControl.GetCart())
            {
                OrderDetails.Items.Add(item);
            }
            foreach (var price in _cartControl.DisplayPrices())
            {
                OrderDetails.Items.Add(price);
            }
        }


        private void label1_Click(object sender, EventArgs e)
        {
            Menu obj1 = new Menu();
            obj1.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            AboutUs obj1 = new AboutUs();
            obj1.Show();
            this.Hide();
        }
    }
}
