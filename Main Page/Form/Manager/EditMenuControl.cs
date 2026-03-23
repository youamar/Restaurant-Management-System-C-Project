using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssingnemntNote;
using System.Windows.Forms;
 
namespace Main_Page
{
    internal class EditMenuControl
    {
        private readonly MenuService _menuService;
        private MenuModel _menuItem;
        private bool _isEditMode;
        private int id;
 
        public EditMenuControl(MenuService menuService, MenuModel menuItem = null)
        {
            _menuService = menuService;
            _menuItem = menuItem;
            _isEditMode = menuItem != null;

            List<MenuModel> list = _menuService.GetAllMenu();
            id = list.Count + 1;
        }
        public void InitializeForm(EditMenu form)
        {
            if (_isEditMode)
            {
                form.ItemID = _menuItem.item_id.ToString();
                form.ItemName = _menuItem.item;
                form.Price = _menuItem.price.ToString();
                form.Description = _menuItem.description;
                form.Category = _menuItem.category_id;
                form.Title = _menuItem.item;
            }
            else
            {
                form.ItemID = id.ToString();
                form.ItemName = "";
                form.Price = "";
                form.Description = "";
                form.Category = "";
                form.Title = "Please Add a new food details";
            }
        }
        public bool ConfirmChanges(EditMenu form)
        {
            if (string.IsNullOrWhiteSpace(form.ItemName) ||
                string.IsNullOrWhiteSpace(form.Price) ||
                string.IsNullOrWhiteSpace(form.Description) ||
                string.IsNullOrWhiteSpace(form.Category))
            {
                MessageBox.Show("Please fill in all fields.");
                return false;
            }
 
            if (!decimal.TryParse(form.Price, out decimal price))
            {
                MessageBox.Show("Invalid price format.");
                return false;
            }

            MenuModel updatedItem = new MenuModel
            {
                item_id = _isEditMode ? _menuItem.item_id : id,  // 如果是新增，item_id 设为 0，数据库自增
                item = form.ItemName,
                description = form.Description,
                price = price,
                category_id = form.Category
            };
 
            bool success;
            if (_isEditMode)
            {
                success = _menuService.UpdateItem(updatedItem.item_id, updatedItem.item, updatedItem.description, updatedItem.price, updatedItem.category_id);
            }
            else
            {
                success = _menuService.AddItem(updatedItem.item_id, updatedItem.item, updatedItem.description, updatedItem.price, updatedItem.category_id, 1);
            }
 
            return success;
        }
    }
}