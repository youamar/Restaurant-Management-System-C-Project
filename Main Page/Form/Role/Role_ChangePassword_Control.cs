using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Class;
using Main_Page.Role;
using System.Windows.Forms;

namespace Main_Page
{
    internal class Role_ChangePassword_Control
    {
        private Form parentform;
        private RoleModel role;
        private TextBox oldpass;
        private TextBox newpass;
        private TextBox newpass2;

        private System.Windows.Forms.Label wrong;
        private System.Windows.Forms.Label nomatch;

        public Role_ChangePassword_Control(Form parentform, TextBox oldpass, TextBox newpass, TextBox newpass2, System.Windows.Forms.Label wrong, System.Windows.Forms.Label nomatch)
        {
            this.parentform = parentform;
            this.oldpass = oldpass;
            this.newpass = newpass;
            this.newpass2 = newpass2;
            this.wrong = wrong;
            this.nomatch = nomatch;
        }

        public void CheckPass()
        {
            wrong.Visible = false;
            nomatch.Visible = false;

            if ((oldpass.Text == "") || (newpass.Text == "") || (newpass2.Text == ""))
            {
                MessageBox.Show("Please Enter All the Column!");
            }
            else 
            {
                RoleService service = new RoleService("VegeMeat");
                role = service.GetRoleByID(SessionManager.Instance.RoleId);

                if (newpass.Text != newpass2.Text)
                {
                    nomatch.Visible = true;
                    MessageBox.Show("Passwords don't match!");
                }

                if (oldpass.Text != role.role_password)
                {
                    wrong.Visible = true;
                    MessageBox.Show("Wrong old password!");
                }

                if (oldpass.Text == role.role_password && newpass.Text == newpass2.Text)
                { 
                    service.UpdatePassword(SessionManager.Instance.RoleId, newpass.Text);
                    MessageBox.Show("Update Successfully!");
                    parentform.Hide();
                }
                else
                {
                    MessageBox.Show("Update Failed!");
                }
            }
        }
    }
}