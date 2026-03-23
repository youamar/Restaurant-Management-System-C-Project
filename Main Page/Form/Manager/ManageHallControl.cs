using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignmemt_inventory;
using System.Windows.Forms;
using Class;

namespace Main_Page
{
    internal class ManageHallControl
    {
        private readonly HallService _hallService;
        private readonly RoleService _roleService;
        private List<HallModel> _hallList;
        private RoleModel _roleModel;

        public ManageHallControl(HallService hallService, RoleService roleService)
        {
            _hallService = hallService;
            _roleService = roleService;
            _hallList = new List<HallModel>();
            _roleModel = new RoleModel();
        }

        public string RoleName()
        {
            _roleModel = _roleService.GetRoleByID(SessionManager.Instance.RoleId);
            return $"{_roleModel.role} {_roleModel.role_name.Split(' ')[0]}";
        }
        
        public void LoadHalls(ListBox listBox)
        {
            listBox.SelectedIndexChanged -= OnSelectedIndexChanged;

            _hallList = _hallService.GetAllHall();
            listBox.Items.Clear();
            foreach (var hall in _hallList)
            {
                listBox.Items.Add($"{hall.hall_id}: {hall.name}");
            }

            listBox.SelectedIndexChanged += OnSelectedIndexChanged;
        }

        private void OnSelectedIndexChanged(object sender, EventArgs e) { }

        public void ShowHallDetails(ListBox lstboxname, Label lblid, Label lblname, Label lblcapacity, Label lbltype, Label lbldescription, Label lblstatus, Button btnactivate)
        {
            if (lstboxname.SelectedIndex == -1) return;
            var selectedHall = _hallList[lstboxname.SelectedIndex];

            lblid.Text = $"Hall ID : {selectedHall.hall_id}";
            lblname.Text = $"Hall Name : {selectedHall.name}";
            lblcapacity.Text = $"Approximate Pax : {selectedHall.maxcapacity}";
            lbltype.Text = $"Party Type : {selectedHall.type}";
            lbldescription.Text = $"{selectedHall.description}";

            if (selectedHall.is_active == 1)
            {
                lblstatus.Text = "# On sales Item";
                btnactivate.Visible = false;
            }
            else if (selectedHall.is_active == 0)
            {
                lblstatus.Text = "# Unavailable Item";
                btnactivate.Visible = true;
            }
            else
            {
                lblstatus.Text = "# Unconfirmed Status";
                btnactivate.Visible = true;
            }
        }
        public void AddNewItem(ListBox lstboxname)
        {
            EditHall addForm = new EditHall(null); // 传 null 代表新增
            if (addForm.ShowDialog() == DialogResult.OK) // 确保用户点击了 "Confirm Changes"
            {
                LoadHalls(lstboxname); // 重新加载 Hall 列表
            }
        }

        // 4. 编辑菜单项
        public void EditItem(int selectedIndex, ListBox lstboxname)
        {
            if (selectedIndex < 0 || selectedIndex >= _hallList.Count)
            {
                MessageBox.Show("Please select a hall to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            EditHall editForm = new EditHall(_hallList[selectedIndex]);
            if (editForm.ShowDialog() == DialogResult.OK) // 只有用户确认修改才更新
            {
                LoadHalls(lstboxname);
            }
        }

        public void DeleteHall(ListBox listBox)
        {
            int selectedIndex = listBox.SelectedIndex;
            if (selectedIndex < 0 || selectedIndex >= _hallList.Count)
            {
                MessageBox.Show("Please select a hall to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var selectedHall = _hallList[listBox.SelectedIndex];
            var confirmResult = MessageBox.Show($"Are you sure you want to delete {selectedHall.name}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                if (_hallService.HallStatus(selectedHall.hall_id , 0))
                {
                    MessageBox.Show("Hall deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadHalls(listBox); // Refresh list
                }
                else
                {
                    MessageBox.Show("Failed to delete hall.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void ActivateHall(ListBox listBox)
        {
            int selectedIndex = listBox.SelectedIndex;
            if (selectedIndex < 0 || selectedIndex >= _hallList.Count)
            {
                MessageBox.Show("Please select a hall to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var selectedHall = _hallList[listBox.SelectedIndex];
            var confirmResult = MessageBox.Show($"Are you sure you want to activate {selectedHall.name}?", "Confirm activate", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                if (_hallService.HallStatus(selectedHall.hall_id, 1))
                {
                    MessageBox.Show("Hall activate successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadHalls(listBox); // Refresh list
                }
                else
                {
                    MessageBox.Show("Failed to activate hall.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
