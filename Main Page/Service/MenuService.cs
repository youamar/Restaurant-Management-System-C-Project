using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssingnemntNote
{
    internal class MenuService
    {
        private readonly MenuRepository _menuRepository;

        public MenuService(string connectionstring)
        {
            _menuRepository = new MenuRepository(connectionstring);
        }

        public MenuModel GetItemByID(int item_id)
        {
            return _menuRepository.GetItemByID(item_id);
        }

        public List<MenuModel> GetAllMenu()
        {
            return _menuRepository.GetAllMenu();
        }

        public List<MenuModel> GetActiveMenu()
        {
            return _menuRepository.GetActiveMenu();
        }

        public bool AddItem(int item_id, string item, string description, decimal price, string category_id, int is_active)
        {
            var MenuModels = new MenuModel { item_id = item_id, item = item, description = description, price = price, category_id = category_id, is_active = is_active };
            return _menuRepository.AddItem(MenuModels, item_id);
        }

        public bool UpdateItem(int item_id, string item, string description, decimal price, string category_id)
        {
            var MenuModels = new MenuModel { item_id = item_id, item = item, description = description, price = price, category_id = category_id };
            return _menuRepository.UpdateItem(MenuModels, item_id);
        }

        public bool ItemStatus(int item_id, int is_active)
        {
            return _menuRepository.ItemStatus(item_id, is_active);
        }
    }
}
