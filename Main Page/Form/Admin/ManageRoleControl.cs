using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Class;
using System.Windows.Forms;

namespace Main_Page
{
    internal class ManageRoleControl
    {
        private readonly RoleService _roleService;
        private List<RoleModel> roles;
        private RoleModel _roleModel;

        private ListBox listBox;
        private Label[] labels;
        private GroupBox groupBox;
        private Button edit;
        private Button delete;

        public ManageRoleControl(ListBox listBox, Label[] labels, GroupBox groupBox, Button edit, Button delete)
        {
            _roleService = new RoleService("VegeMeat");

            this.listBox = listBox;
            this.labels = labels;
            this.groupBox = groupBox;
            this.edit = edit;
            this.delete = delete;
        }

        public string RoleName()
        {
            _roleModel = _roleService.GetRoleByID(SessionManager.Instance.RoleId);
            return $"{_roleModel.role} {_roleModel.role_name.Split(' ')[0]}";
        }

        public void LoadStaffID()
        {
            listBox.SelectedIndexChanged -= OnSelectedIndexChanged;

            roles = _roleService.GetAllRole();
            listBox.Items.Clear();
            foreach (var role in roles)
            {
                listBox.Items.Add($"{role.role_id}");
            }

            listBox.SelectedIndexChanged += OnSelectedIndexChanged;
        }

        private void OnSelectedIndexChanged(object sender, EventArgs e) { }

        public void ShowStaffDetails()
        {
            if (listBox.SelectedIndex == -1) return;
            var selectedRole = roles[listBox.SelectedIndex];

            RoleModel role = _roleService.AdminGetRoleByID(selectedRole.role_id);

            if (role.role_status == 1)
            {
                groupBox.Text = role.role_id.ToString();
            }
            else
            {
                groupBox.Text = "Terminated Employee";
                delete.Visible = false;
                edit.Visible = false;
            }

            labels[0].Text = $"Name : {role.role_name}";
            labels[1].Text = $"Phone Number : {role.role_contact}";
            labels[2].Text = $"Identity Number : {role.role_ic}";
            labels[3].Text = $"Email Address : {role.role_email}";
            labels[4].Text = $"Password :{role.role_password}";
            labels[5].Text = $"Role : {role.role}";
        }

        public void AddNewStaff()
        {
            AdminRoleEdit addForm = new AdminRoleEdit(null);
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadStaffID();
            }
        }

        public void EditItem()
        {
            if (listBox.SelectedIndex < 0 || listBox.SelectedIndex >= roles.Count)
            {
                MessageBox.Show("Please select a staff to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            AdminRoleEdit editForm = new AdminRoleEdit(roles[listBox.SelectedIndex]);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadStaffID();
            }
        }

        public void DeleteRole()
        {
            if (listBox.SelectedIndex < 0 || listBox.SelectedIndex >= roles.Count)
            {
                MessageBox.Show("Please select a staff to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var selectedRole = roles[listBox.SelectedIndex];
            var confirmResult = MessageBox.Show($"Are you sure you want to delete {selectedRole.role_name}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                if (_roleService.DeleteRole(selectedRole.role_id))
                {
                    MessageBox.Show("Staff deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadStaffID();
                }
                else
                {
                    MessageBox.Show("Failed to delete staff.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
