using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IOOP;
using Main_Page;

namespace Main_Page
{
    public partial class UpdateInventory : Form
    {
        private UpdateInventoryControl _editInventoryControl;

        public UpdateInventory()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

            _editInventoryControl = new UpdateInventoryControl("VegeMeat");
            lblTitle.Text = _editInventoryControl.RoleTitle();

            LoadInventoryList();
        }

        private void LoadInventoryList()
        {
            var inventories = _editInventoryControl.GetAllInventory();

            lstingredient.DataSource = inventories;
            lstingredient.DisplayMember = "ingredient_name";
            lstingredient.ValueMember = "ingredient_id";
        }

        private void lstingredient_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstingredient.SelectedItem == null) return;

            string selectedId = lstingredient.SelectedValue.ToString();
            var inventory = _editInventoryControl.GetInventoryById(selectedId);

            if (inventory != null)
            {
                lblname.Text = $"Ingredient Name: {inventory.ingredient_name}";
                lblquantity.Text = $"Stock Quantity: {inventory.stock}";
                lblsafety.Text = $"Safety Stock: {inventory.safety_stock}";
            }
        }

        private void btnaddnew_Click(object sender, EventArgs e)
        {
            EditInventoryControl _editInventoryControl = new EditInventoryControl("VegeMeat");

            EditInventory addForm = new EditInventory(_editInventoryControl);
            addForm.ShowDialog();
            LoadInventoryList();
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            if (lstingredient.SelectedItem == null)
            {
                MessageBox.Show("Please select an ingredient to delete.");
                return;
            }

            string selectedId = lstingredient.SelectedValue.ToString();
            var confirmResult = MessageBox.Show("Delete this ingredient?", "Confirm", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                bool success = _editInventoryControl.SetStockToZero(selectedId);
                if (success)
                {
                    MessageBox.Show("Are you sure you want to delete this ingredient?");
                    LoadInventoryList();
                }
                else
                {
                    MessageBox.Show("Update failed.");
                }
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            if (lstingredient.SelectedItem == null)
            {
                MessageBox.Show("Please select an ingredient to edit.");
                return;
            }

            var selectedInventory = (InventoryModel)lstingredient.SelectedItem;
            var _editInventoryControl = new EditInventoryControl("VegeMeat", selectedInventory);
            var editForm = new EditInventory(_editInventoryControl);
            editForm.ShowDialog();
            LoadInventoryList();
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







