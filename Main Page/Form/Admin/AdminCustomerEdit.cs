using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;
using Class;

namespace Main_Page
{
    public partial class AdminCustomerEdit : Form
    {
        private AdminCustomerEditControl control;

        public AdminCustomerEdit(CustomerModel customer)
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

            TextBox[] boxs = new TextBox[] { name, contact, email, birthday };

            control = new AdminCustomerEditControl(this, customer, boxs, lblTitle);
            control.LoadCustomerData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            control.SaveChanges();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ManageCustomer customer = new ManageCustomer();
            customer.Show();
            this.Hide();
        }
    }
}
