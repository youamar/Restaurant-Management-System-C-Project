using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Main_Page
{
    public partial class ManageCustomer : Form
    {
        ManageCustomerControl control;

        public ManageCustomer()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

            Label[] labels = new Label[] { lblname, lblcontact, lblemail, lblbirthday };

            control = new ManageCustomerControl(lststaff, labels, groupBox);
            control.LoadCustomerID();

            lblTitle.Text = control.RoleName();
        }

        private void lststaff_SelectedIndexChanged(object sender, EventArgs e)
        {
            control.ShowCustomerDetails();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            control.EditItem();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            control.DeleteCustomer();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            control.AddNewCustomer();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            ManageCustomer customer = new ManageCustomer();
            customer.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            ManageRole role = new ManageRole();
            role.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            ViewFeedback viewFeedback = new ViewFeedback();
            viewFeedback.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            ViewSalesReport report = new ViewSalesReport();
            report.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Role_Profile role = new Role_Profile();
            role.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            SessionManager.Instance.Logout();
            Customer_Login customer_Login = new Customer_Login();
            customer_Login.Show();
            this.Hide();
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {
            control.LoadCustomerID();
        }
    }
}