using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Assignmemt_inventory;
using System.Xml.Linq;
using Class;

namespace Main_Page
{
    internal class AdminRoleEditControl
    {
        private RoleService roleService;
        private RoleModel roles;

        private TextBox[] boxs;
        private ComboBox comboBox;
        private Label title;
        private Form parentForm;

        private bool _isEditMode;

        public AdminRoleEditControl(Form parentForm, RoleModel roles, TextBox[] textBoxes, ComboBox comboBox, Label title) 
        {
            roleService = new RoleService("VegeMeat");

            this.parentForm = parentForm;
            this.roles = roles;
            this.boxs = textBoxes;
            this.comboBox = comboBox;
            this.title = title;

            _isEditMode = roles != null;
        }

        public void LoadRoleData()
        {
            if (_isEditMode)
            {
                title.Text = "Editing Staff Details ";

                boxs[5].Text = roles.role_id;
                boxs[0].Text = roles.role_name;
                boxs[1].Text = roles.role_contact;
                boxs[2].Text = roles.role_ic;
                boxs[3].Text = roles.role_email;
                boxs[4].Text = roles.role_password;
                comboBox.Text = roles.role;

                boxs[5].Enabled = false;
            }
            else
            {
                title.Text = "Please Add a new staff details";
            }
        }

        public void SaveChanges()
        {
            if (string.IsNullOrWhiteSpace(boxs[0].Text) ||
                string.IsNullOrWhiteSpace(boxs[1].Text) ||
                string.IsNullOrWhiteSpace(boxs[2].Text) ||
                string.IsNullOrWhiteSpace(boxs[3].Text) ||
                string.IsNullOrWhiteSpace(boxs[4].Text) ||
                string.IsNullOrWhiteSpace(comboBox.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (_isEditMode)
            {
                bool success = roleService.AdminUpdateRole(roles.role_id, boxs[4].Text, boxs[0].Text, boxs[2].Text, boxs[1].Text, boxs[3].Text, comboBox.Text);
                if (success)
                {
                    MessageBox.Show("Staff updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    parentForm.Hide();
                }
                else
                {
                    MessageBox.Show("Failed to update staff.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // 新增到数据库
                bool success = roleService.AddRole(boxs[5].Text, boxs[4].Text, boxs[0].Text, boxs[2].Text, boxs[1].Text, boxs[3].Text, comboBox.Text);
                if (success)
                {
                    MessageBox.Show("New staff added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    parentForm.Hide();
                }
                else
                {
                    MessageBox.Show("Failed to add staff.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
