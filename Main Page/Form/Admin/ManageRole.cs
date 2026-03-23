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
    public partial class ManageRole : Form
    {
        private ManageRoleControl control;

        public ManageRole()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

            Label[] labels = new Label[] { lblname, lblcontact, lblic, lblemail, lblpassword, lblrole };

            control = new ManageRoleControl(lststaff, labels, groupBox, btnEdit, btnDelete);
            control.LoadStaffID();

            lblTitle.Text = control.RoleName();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            control.AddNewStaff();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            control.EditItem();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            control.DeleteRole();
        }

        private void lststaff_SelectedIndexChanged(object sender, EventArgs e)
        {
            control.ShowStaffDetails();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            ManageCustomer customer = new ManageCustomer();
            customer.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            ManageRole manageRole = new ManageRole();
            manageRole.Show();
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
            ViewSalesReport viewSalesReport = new ViewSalesReport();
            viewSalesReport.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Role_Profile role_Profile = new Role_Profile();
            role_Profile.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            SessionManager.Instance.Logout();
            Customer_Login customer_Login = new Customer_Login();
            customer_Login.Show();
            this.Hide();
        }
    }
}
