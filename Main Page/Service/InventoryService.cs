using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOOP
{
    internal class InventoryService
    {
        private readonly InventoryRepository _inventoryRepository;

        public InventoryService(string connectionString)
        {
            _inventoryRepository = new InventoryRepository(connectionString);
        }

        public List<InventoryModel> GetAllInventory()
        {
            return _inventoryRepository.GetAllInventory();
        }

        public bool EditInventory(string ingredient_id, int stock)
        {
            var inventoryModels = new InventoryModel { ingredient_id = ingredient_id, stock = stock };
            return _inventoryRepository.UpdateInventory(inventoryModels, ingredient_id);
        }

        public bool AddInventory(InventoryModel inventoryModel)
        {
            return _inventoryRepository.AddInventory(inventoryModel);
        }
    }
}
