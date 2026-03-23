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
    public partial class ViewSalesReport : Form
    {
        private ViewSalesReportControl control;

        public ViewSalesReport()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

            control = new ViewSalesReportControl(listboxreport, btnMonth, btnCategory, btnChef);
            int year = DateTime.Now.Year;

            lblTitle.Text = control.RoleName();
        }

        private void btnMonth_Click(object sender, EventArgs e)
        {
            control.LoadMonth();
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            control.LoadCategory();
        }

        private void btnChef_Click(object sender, EventArgs e)
        {
            control.LoadChef();
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
