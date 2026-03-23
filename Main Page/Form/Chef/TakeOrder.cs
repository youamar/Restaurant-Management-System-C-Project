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
using IOOP;

namespace Main_Page
{
    public partial class TakeOrder : Form
    {
        private readonly TakeOrderControl _takeOrderControl;

        public TakeOrder()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

            _takeOrderControl = new TakeOrderControl("VegeMeat");
            lblTitle.Text = _takeOrderControl.RoleTitle();

            LoadOrderList();
            lstname.SelectedIndexChanged += lstname_SelectedIndexChanged;

        }
        private void LoadOrderList()
        {
            lstname.Items.Clear();
            var orderDetails = _takeOrderControl.GetAllOrderDetails();
            foreach (var orderId in orderDetails)
            {
                lstname.Items.Add($"{orderId.detail_id} - {orderId.status}");
            }
        }

        private void lstname_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstname.SelectedItem == null) return;

            string selectedDetailId = lstname.SelectedItem.ToString().Split(' ')[0];
            var (itemName, quantity, status) = _takeOrderControl.GetOrderInfo(selectedDetailId);

            lblitem.Text = "Name: " + itemName;
            lblquantity.Text = "Quantity: " + quantity;
            lblstatus.Text = "Status: " + status;

            if (status == "Completed")
            {
                btncomplete.Visible = false;
                btnprepare.Visible = false;
            }
            else
            {
                btncomplete.Visible = true;
                btnprepare.Visible = true;
            }

            LoadIngredientList(selectedDetailId);
        }

        private void LoadIngredientList(string detail_id)
        {
            lstingredient.Items.Clear();
            var ingredients = _takeOrderControl.GetIngredientsForOrder(detail_id);
            foreach (var (ingredientName, requiredQuantity) in ingredients)
            {
                lstingredient.Items.Add($"{ingredientName} - {requiredQuantity}");
            }
        }

        private void btncomplete_Click(object sender, EventArgs e)
        {
            if (lstname.SelectedItem == null) return;

            string selectedDetailId = lstname.SelectedItem.ToString().Split(' ')[0];
            if (_takeOrderControl.CompleteOrderAndUpdateInventory(selectedDetailId))
            {
                lstname.Text = "Status: Completed";
                MessageBox.Show("Order marked as Completed and inventory updated.");
                if (_takeOrderControl.UpdateInvoiceStatus(selectedDetailId))
                {
                    MessageBox.Show("All Orders Done!");
                }
                LoadOrderList();
            }
            else
            {
                MessageBox.Show("Failed to update status.");
            }
        }

        private void btnprepare_Click(object sender, EventArgs e)
        {
            if (lstname.SelectedItem == null) return;

            string selectedDetailId = lstname.SelectedItem.ToString().Split(' ')[0];
            if (_takeOrderControl.UpdateOrderStatus(selectedDetailId, "Preparing"))
            {
                lblstatus.Text = "Status: Preparing";
                MessageBox.Show("Order status updated to Preparing.");
                LoadOrderList();
            }
            else
            {
                MessageBox.Show("Failed to update status.");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            TakeOrder takeOrder = new TakeOrder();
            takeOrder.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            UpdateInventory updateInventory = new UpdateInventory();
            updateInventory.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Role_Profile profile = new Role_Profile();
            profile.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            SessionManager.Instance.Logout();
            Customer_Login obj1 = new Customer_Login();
            obj1.Show();
            this.Hide();
        }

        private void btnall_Click(object sender, EventArgs e)
        {
            LoadOrderList();
        }

        private void btnpending_Click(object sender, EventArgs e)
        {
            lstname.Items.Clear();
            var orderDetails = _takeOrderControl.GetAllOrderDetails();
            foreach (var orderId in orderDetails)
            {
                if (orderId.status == "Pending" || orderId.status == "Preparing")
                {
                    lstname.Items.Add($"{orderId.detail_id} - {orderId.status}");
                }
            }
        }
    }
}
