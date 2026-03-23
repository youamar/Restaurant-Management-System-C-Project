using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Class;
using IOOP;

namespace Main_Page
{
    internal class UpdateInventoryControl
    {
        private readonly InventoryService _inventoryService;
        private readonly RoleService _roleService;

        public UpdateInventoryControl(string connectionString)
        {
            _inventoryService = new InventoryService(connectionString);
            _roleService = new RoleService(connectionString);
        }

        public string RoleTitle()
        {
            RoleModel role = _roleService.GetRoleByID(SessionManager.Instance.RoleId);
            return $"{role.role} {role.role_name.Split(' ')[0]}";
        }

        public List<InventoryModel> GetAllInventory()
        {
            return _inventoryService.GetAllInventory();
        }

        public InventoryModel GetInventoryById(string ingredientId)
        {
            var inventories = _inventoryService.GetAllInventory();
            return inventories.FirstOrDefault(i => i.ingredient_id == ingredientId);
        }

        public bool SetStockToZero(string ingredientId)
        {
            return _inventoryService.EditInventory(ingredientId, 0);
        }
    }
}