using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AssingnemntNote;

namespace Main_Page
{
    public partial class ManageMenu : Form
    {
        private ManageMenuControl _manageMenuControl;

        public ManageMenu()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

            _manageMenuControl = new ManageMenuControl("VegeMeat");
            lblTitle.Text = _manageMenuControl.RoleName();

            LoadMenu();
        }

        private void LoadMenu()
        {
            lstboxname.Items.Clear();  // 先清空列表
            lstboxname.Items.AddRange(_manageMenuControl.LoadMenuItems().ToArray());  // 重新加载
        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = lstboxname.SelectedIndex;
            MenuModel selectedItem = _manageMenuControl.GetSelectedMenuItem(selectedIndex);

            if (selectedItem != null)
            {
                lblManagerMenuTitle.Text = selectedItem.item;
                lblprice.Text = $"${selectedItem.price}";
                lbldescription.Text = selectedItem.description;

                if (selectedItem.is_active == 1)
                {
                    lblactive.Text = "# On sales Item";
                    btnactivate.Visible = false;
                }
                else if (selectedItem.is_active == 0)
                {
                    lblactive.Text = "# Unavailable Item";
                    btnactivate.Visible = true;
                }
                else
                {
                    lblactive.Text = "# Unconfirmed Status";
                    btnactivate.Visible = true;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int selectedIndex = lstboxname.SelectedIndex;

            if (selectedIndex >= 0)
            {
                bool isDeleted = _manageMenuControl.DeleteItem(selectedIndex);
                if (isDeleted)
                {
                    MessageBox.Show("Item deleted successfully!");
                    LoadMenu();  // 重新加载菜单
                }
                else
                {
                    MessageBox.Show("Failed to delete item.");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EditMenu addMenuForm = new EditMenu(); // 创建"添加菜单项"窗口
            if (addMenuForm.ShowDialog() == DialogResult.OK) // 用户成功添加
            {
                LoadMenu();  // 重新加载菜单数据
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int selectedIndex = lstboxname.SelectedIndex;
            if (selectedIndex < 0)
            {
                MessageBox.Show("Please select a menu item to edit.");
                return;
            }

            // 获取选中的菜单项
            MenuModel selectedItem = _manageMenuControl.GetSelectedMenuItem(selectedIndex);
            if (selectedItem == null) return;

            EditMenu editMenuForm = new EditMenu(selectedItem); // 传入选中项
            if (editMenuForm.ShowDialog() == DialogResult.OK) // 用户成功编辑
            {
                LoadMenu();
            }
        }

        private void btnactivate_Click(object sender, EventArgs e)
        {
            int selectedIndex = lstboxname.SelectedIndex;

            if (selectedIndex >= 0)
            {
                bool isDeleted = _manageMenuControl.ActivateItem(selectedIndex);
                if (isDeleted)
                {
                    MessageBox.Show("Item activate successfully!");
                    LoadMenu();  // 重新加载菜单
                }
                else
                {
                    MessageBox.Show("Failed to activate item.");
                }
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            Role_Profile profile = new Role_Profile();
            profile.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            ManageHall hall = new ManageHall();
            hall.Show();
            this.Hide();
        }

        private void profile_Click(object sender, EventArgs e)
        {
            Role_Profile profile = new Role_Profile();
            profile.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            ManageMenu menu = new ManageMenu();
            menu.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            SessionManager.Instance.Logout();
            Customer_Login obj1 = new Customer_Login();
            obj1.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            HallReport hall = new HallReport();
            hall.Show();
            this.Hide();
        }
    }
}
