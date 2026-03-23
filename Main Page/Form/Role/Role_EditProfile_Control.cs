using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Class;

namespace Main_Page
{
    internal class Role_EditProfile_Control
    {
        private Form parentform;
        private TextBox name;
        private TextBox contact;
        private TextBox ic;
        private TextBox email;
        private RoleModel role;
        private string id;

        public Role_EditProfile_Control(Form parentform, TextBox name, TextBox contact, TextBox ic, TextBox email)
        {
            this.parentform = parentform;
            this.name = name;
            this.contact = contact;
            this.ic = ic;
            this.email = email;
        }

        public void LoadData()
        {
            RoleService _roleservice = new RoleService("VegeMeat");
            role = _roleservice.GetRoleByID(SessionManager.Instance.RoleId);
            name.Text = role.role_name;
            contact.Text = role.role_contact;
            ic.Text = role.role_ic;
            email.Text = role.role_email;

        }

        public void Update()
        {
            RoleService _roleservice = new RoleService("VegeMeat");
            if (_roleservice.UpdateRole(SessionManager.Instance.RoleId, name.Text, ic.Text, contact.Text, email.Text))
            {
                MessageBox.Show("Update Successfully!");
                parentform.Hide();
            }
        }

    }
}