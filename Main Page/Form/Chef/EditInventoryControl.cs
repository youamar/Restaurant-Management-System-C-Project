using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOOP;
using System.Windows.Forms;
using AssingnemntNote;

namespace Main_Page
{
    public class EditInventoryControl
    {
        private readonly InventoryService _inventoryService;
        private InventoryModel _currentInventory;
        private bool _isEditMode;
        private string id;
        public EditInventoryControl(string connectionString, InventoryModel inventoryItem = null)
        {
            _inventoryService = new InventoryService(connectionString);
            _currentInventory = inventoryItem;
            _isEditMode = inventoryItem != null;

            List<InventoryModel> list = _inventoryService.GetAllInventory();
            id = $"I00{list.Count + 1}";
        }

        public void InitializeForm(EditInventory form)
        {
            if (_isEditMode)
            {
                form.IngredientID = _currentInventory.ingredient_id;
                form.IngredientName = _currentInventory.ingredient_name;
                form.Stock = _currentInventory.stock.ToString();
                form.Safty = _currentInventory.safety_stock.ToString();
                form.Title = $"Editing: {_currentInventory.ingredient_name}";
            }
            else
            {


                form.IngredientID = id;
                form.IngredientName = "";
                form.Stock = "";
                form.Safty = "";
                form.Title = "Add a new ingredient:";
            }
        }

        public bool ConfirmChanges(EditInventory form)
        {
            if (string.IsNullOrWhiteSpace(form.IngredientName) ||
                string.IsNullOrWhiteSpace(form.Stock) ||
                string.IsNullOrWhiteSpace(form.Safty))
            {
                MessageBox.Show("Please fill in all fields.");
                return false;
            }

            if (!double.TryParse(form.Stock, out double stock) ||
                !double.TryParse(form.Safty, out double safetyStock))
            {
                MessageBox.Show("Invalid stock or safety stock format.");
                return false;
            }

            InventoryModel updatedIngredient = new InventoryModel
            {
                ingredient_id = _isEditMode ? _currentInventory.ingredient_id : form.IngredientID, // ✅ 保留 ID
                ingredient_name = form.IngredientName,
                stock = stock,
                safety_stock = safetyStock
            };

            bool success;
            if (_isEditMode)
            {
                success = _inventoryService.EditInventory(updatedIngredient.ingredient_id, (int)updatedIngredient.stock);
            }
            else
            {
                success = _inventoryService.AddInventory(updatedIngredient);
            }

            return success;
        }
    }
}