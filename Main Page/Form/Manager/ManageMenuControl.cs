using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssingnemntNote;
using System.Windows.Forms;
using Class;

namespace Main_Page
{
    internal class ManageMenuControl
    {
        private readonly MenuService _menuService;
        private readonly RoleService _roleService;
        private List<MenuModel> _menuList;
        private RoleModel _roleModel;

        public ManageMenuControl(string connectionString)
        {
            _menuService = new MenuService(connectionString);
            _roleService = new RoleService(connectionString);
            _menuList = new List<MenuModel>();
            _roleModel = new RoleModel();
        }

        public string RoleName()
        {
            _roleModel = _roleService.GetRoleByID(SessionManager.Instance.RoleId);
            return $"{_roleModel.role} {_roleModel.role_name.Split(' ')[0]}";
        }

        // 1. 加载所有菜单项，返回菜单名称列表（供 UI 显示）
        public List<string> LoadMenuItems()
        {
            _menuList = _menuService.GetAllMenu();
            return _menuList.Select(menu => menu.item).ToList();
        }

        // 2. 获取选中的菜单详情
        public MenuModel GetSelectedMenuItem(int selectedIndex)
        {
            if (selectedIndex < 0 || selectedIndex >= _menuList.Count)
                return null;
            return _menuList[selectedIndex];
        }

        // 3. 添加新菜单项
        public void AddNewItem()
        {
            EditMenu addForm = new EditMenu(null); // 传 null 代表新增
            addForm.ShowDialog();
        }

        // 4. 编辑菜单项
        public void EditItem(int selectedIndex)
        {
            if (selectedIndex < 0 || selectedIndex >= _menuList.Count)
                return;

            EditMenu editForm = new EditMenu(_menuList[selectedIndex]);
            editForm.ShowDialog();
        }

        // 5. 删除菜单项
        public bool DeleteItem(int selectedIndex)
        {
            if (selectedIndex < 0 || selectedIndex >= _menuList.Count)
                return false;

            MenuModel menu = _menuList[selectedIndex];

            DialogResult result = MessageBox.Show($"Are you sure you want to delete {menu.item}?",
                                                  "Confirm Delete", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                return _menuService.ItemStatus(menu.item_id, 0);
            }

            return false;
        }

        public bool ActivateItem(int selectedIndex)
        {
            if (selectedIndex < 0 || selectedIndex >= _menuList.Count)
                return false;

            MenuModel menu = _menuList[selectedIndex];

            DialogResult result = MessageBox.Show($"Are you sure you want to activate {menu.item}?",
                                                  "Confirm Avtivate", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                return _menuService.ItemStatus(menu.item_id, 1);
            }

            return false;
        }
    }
}