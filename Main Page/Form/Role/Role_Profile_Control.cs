using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Class;

namespace Main_Page
{
    internal class Role_Profile_Control
    {
        private Label id;
        private Label contact;
        private Label email;
        private Label ic;
        private Label title;
        private RoleModel role;

        public Role_Profile_Control(Label id, Label contact, Label email, Label ic, Label title)
        {
            this.id = id;
            this.contact = contact;
            this.email = email;
            this.ic = ic;
            this.title = title;
        }

        public void Profile()
        {
            RoleService _roleService = new RoleService("VegeMeat");
            role = _roleService.GetRoleByID(SessionManager.Instance.RoleId);
            id.Text = $"Staff ID : {role.role_id}";
            contact.Text = $"Phone Number : 60{role.role_contact}";
            email.Text = $"Email Address : {role.role_email}";
            ic.Text = $"Identity No : {role.role_ic}";

            title.Text = $"Hi, {role.role} {role.role_name}";
        }
    }
}