using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Class;

namespace Main_Page
{
    public partial class AdminRoleEdit : Form
    {
        private AdminRoleEditControl control;

        public AdminRoleEdit(RoleModel role)
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

            TextBox[] boxs = new TextBox[] { name, contact, ic, email, password, txtid };

            control = new AdminRoleEditControl(this, role, boxs, cmbrole, lblTitle);
            control.LoadRoleData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            control.SaveChanges();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ManageRole manageRole = new ManageRole();
            manageRole.Show();
            this.Hide();
        }
    }
}
