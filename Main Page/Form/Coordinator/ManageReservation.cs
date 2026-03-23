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
    public partial class ManageReservation: Form
    {

        private ManageReservationControl control;

        public ManageReservation()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

            control = new ManageReservationControl(lstall, lstdetail, cmbhall);
            lblTitle.Text = control.LoadRoleTItle();
            control.LoadAllReservations();
            control.LoadAllHall();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            control.UpdateStatus("APPROVED");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            control.UpdateStatus("COMPLETED");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            control.UpdateStatus("DECLINED");
        }

        private void lstall_SelectedIndexChanged(object sender, EventArgs e)
        {
            control.ShowReservationDetails();
        }

        private void btnhall_Click(object sender, EventArgs e)
        {
            control.AssignHall();
        }

        private void btnreply_Click(object sender, EventArgs e)
        {
            control.ReplyMessage(txtreply.Text);
        }

        private void label8_Click(object sender, EventArgs e)
        {
            control.ViewCustomerProfile();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            ManageReservation manageReservation = new ManageReservation();
            manageReservation.Show();
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
    }
}
