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
    public partial class HallReport : Form
    {
        private HallReportControl control;

        public HallReport()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

            control = new HallReportControl(lsthall);
            control.loadHall();
            lblTitle.Text = control.RoleName();
        }

        private void lstboxname_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label[] labels = new Label[] {lblid,lblname,lblcapacity,lbltype,lbldescription,lblavailility,lblreservation,lblexpriencing};
            control.loadHallData(labels);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            SessionManager.Instance.Logout();
            Customer_Login customer_Login = new Customer_Login();
            customer_Login.Show();
            this.Hide();
        }

        private void profile_Click(object sender, EventArgs e)
        {
            Role_Profile role_Profile = new Role_Profile();
            role_Profile.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            HallReport hallReport = new HallReport();
            hallReport.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            ManageHall manageHall = new ManageHall();
            manageHall.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            ManageMenu manageMenu = new ManageMenu();
            manageMenu.Show();
            this.Hide();
        }
    }
}
