using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Assignmemt_inventory;
using Class;

namespace Main_Page
{
    public partial class ManageHall : Form
    {
        private ManageHallControl _manageHallControl;

        public ManageHall()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

            _manageHallControl = new ManageHallControl(new HallService("VegeMeat"), new RoleService("VegeMeat"));
            lblTitle.Text = _manageHallControl.RoleName();

            RegisterEventHandlers();
        }

        private void RegisterEventHandlers()
        {
            Load -= ManageHall_Load;
            Load += ManageHall_Load;

            lstboxname.SelectedIndexChanged -= lstboxname_SelectedIndexChanged;
            lstboxname.SelectedIndexChanged += lstboxname_SelectedIndexChanged;

            btnaddnew.Click -= btnaddnew_Click;
            btnaddnew.Click += btnaddnew_Click;

            btnEdit.Click -= btnEdit_Click;
            btnEdit.Click += btnEdit_Click;

            btndelete.Click -= button1_Click;
            btndelete.Click += button1_Click;

            btnactivate.Click -= btnactivate_Click;
            btnactivate.Click += btnactivate_Click;
        }

        private void button1_Click(object sendSer, EventArgs e)
        {
            _manageHallControl.DeleteHall(lstboxname);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            _manageHallControl.EditItem(lstboxname.SelectedIndex, lstboxname);
        }

        private void btnaddnew_Click(object sender, EventArgs e)
        {
            _manageHallControl.AddNewItem(lstboxname);
        }

        private void lstboxname_SelectedIndexChanged(object sender, EventArgs e)
        {
            _manageHallControl.ShowHallDetails(lstboxname, lblid, lblname, lblcapacity, lbltype, lbldescription, lblstatus, btnactivate);
        }

        private void ManageHall_Load(object sender, EventArgs e)
        {
            _manageHallControl.LoadHalls(lstboxname);
        }

        private void btnactivate_Click(object sender, EventArgs e)
        {
            _manageHallControl.ActivateHall(lstboxname);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            ManageMenu menu = new ManageMenu();
            menu.Show();
            this.Hide();
        }

        private void profile_Click(object sender, EventArgs e)
        {
            Role_Profile profile = new Role_Profile();
            profile.Show();
            profile.BringToFront();

        }

        private void label2_Click(object sender, EventArgs e)
        {
            ManageHall hall = new ManageHall();
            hall.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            HallReport hallReport = new HallReport();
            hallReport.Show();
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
