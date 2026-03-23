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
    public partial class ViewFeedback : Form
    {
        private ViewFeedbackControl feedbackcontrol;

        public ViewFeedback()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

            feedbackcontrol = new ViewFeedbackControl(listBox1, lblfeedback, lblrating);
            feedbackcontrol.LoadFeedback();

            lblTitle.Text = feedbackcontrol.RoleName();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            feedbackcontrol.GetSelectedFeedback();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Role_Profile role_Profile = new Role_Profile();
            role_Profile.Show();
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            SessionManager.Instance.Logout();
            Customer_Login customer_Login = new Customer_Login();
            customer_Login.Show();
            this.Hide();
        }
    }
}
