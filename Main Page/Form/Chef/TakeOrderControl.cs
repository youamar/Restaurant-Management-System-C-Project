using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using AssingnemntNote;
using Class;
using IOOP;

namespace Main_Page
{
    internal class TakeOrderControl
    {
        private readonly OrderDetailService _orderDetailService;
        private readonly MenuService _menuService;
        private readonly RecipeService _recipeService;
        private readonly InvoiceService _invoiceService;
        private readonly RoleService _roleService;

        public TakeOrderControl(string connectionString)
        {
            _orderDetailService = new OrderDetailService(connectionString);
            _menuService = new MenuService(connectionString);
            _recipeService = new RecipeService(connectionString);
            _invoiceService = new InvoiceService(connectionString);
            _roleService = new RoleService(connectionString);
        }

        public string RoleTitle()
        {
            RoleModel role = _roleService.GetRoleByID(SessionManager.Instance.RoleId);
            return $"{role.role} {role.role_name.Split(' ')[0]}";
        }

        public List<OrderDetailModel> GetAllOrderDetails()
        {   
            return _orderDetailService.GetAllOrder(null);
        }

        public OrderDetailModel GetOrderDetail(string detail_id)
        {
            return _orderDetailService.GetAllOrder(detail_id).FirstOrDefault();
        }

        public (string itemName, int quantity, string status) GetOrderInfo(string detail_id)
        {
            var orderDetail = GetOrderDetail(detail_id);
            if (orderDetail == null) return ("Unknown", 0, "Unknown");

            var menuItem = _menuService.GetItemByID(orderDetail.item_id);
            return (menuItem?.item ?? "Unknown", orderDetail.quantity, orderDetail.status);
        }

        public List<(string ingredientName, double requiredQuantity)> GetIngredientsForOrder(string detail_id)
        {
            var orderDetail = GetOrderDetail(detail_id);
            if (orderDetail == null) return new List<(string, double)>();
            var recipeList = _recipeService.GetRecipeFromItem(orderDetail.item_id);
            return recipeList.Select(r => (r.ingredient_id, r.require_quantitiy)).ToList();
        }

        public bool UpdateOrderStatus(string detail_id, string newStatus)
        {
            return _orderDetailService.UpdateOrderStatus(detail_id, newStatus, SessionManager.Instance.RoleId);
        }

        public bool CompleteOrderAndUpdateInventory(string detail_id)
        {
            var order = GetOrderDetail(detail_id);
            if (order == null) return false;

            bool statusUpdated = _orderDetailService.UpdateOrderStatus(detail_id, "Completed", SessionManager.Instance.RoleId);
            if (statusUpdated)
            {
                return _orderDetailService.CompleteOrderAndUpdateInventory(detail_id, order.item_id, order.quantity, SessionManager.Instance.RoleId);
            }

            return false;
        }

        public bool UpdateInvoiceStatus(string detail_id)
        {
            OrderDetailModel order = GetOrderDetail(detail_id);
            List<OrderDetailModel> orders = _orderDetailService.GetOrderDetailByID(order.order_id);

            bool allCompleted = orders.All(r => r.status == "Completed");

            if (allCompleted)
            {
                _invoiceService.UpdateInvoiceStatus(order.order_id, "Completed");
                return true;
            }

            return false;
        }
    }
}