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
    public partial class EditInventory : Form
    {
        private readonly EditInventoryControl _editInventoryControl;
        private readonly string _ingredientId;
        private bool _isEditMode;

        public EditInventory(EditInventoryControl editInventoryControl)
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

            _editInventoryControl = editInventoryControl;
            _editInventoryControl.InitializeForm(this);
        }

        public string IngredientID
        {
            get { return txtid.Text; }
            set { txtid.Text = value; }
        }

        public string IngredientName
        {
            get { return txtname.Text; }
            set { txtname.Text = value; }
        }

        public string Stock
        {
            get { return txtquantity.Text; }
            set { txtquantity.Text = value; }
        }

        public string Safty
        {
            get { return txtsafety.Text; }
            set { txtsafety.Text = value; }
        }
        public string Title
        {
            get { return lblTitle.Text; }
            set { lblTitle.Text = value; }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_editInventoryControl.ConfirmChanges(this))
            {
                MessageBox.Show("Changes saved successfully!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
