using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Main_Page;
using Main_Page.Order;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AssingnemntNote
{
    internal class OrderDetailService
    {
        private readonly OrderDetailRepository _orderDetailRepository;

        public OrderDetailService(string connectionString)
        {
            _orderDetailRepository = new OrderDetailRepository(connectionString);
        }

        public List<OrderDetailModel> GetOrderDetailByID(string order_id)
        {
            return _orderDetailRepository.GetOrderDetailByID(order_id);
        }

        public List<OrderDetailModel> GetAllOrder(string detail_id)
        {
            return _orderDetailRepository.GetAllOrder(detail_id);
        }

        public List<OrderDetailModel> GetStatusbyIncompleteInvoice(string customer_id)
        {
            return _orderDetailRepository.GetStatusbyIncompleteInvoice(customer_id);
        }

        public void AddOrderDetail(OrderDetailModel detail)
        {
            _orderDetailRepository.AddOrderDetail(detail);
        }

        public bool UpdateOrderStatus(string detail_id, string newstatus, string role_id)
        {
            return _orderDetailRepository.UpdateOrderStatus(detail_id, newstatus, role_id);
        }

        public bool CompleteOrderAndUpdateInventory(string detail_id, int item_id, int quantity, string role_id)
        {
            // 1. 先更新订单状态
            bool statusUpdated = _orderDetailRepository.UpdateOrderStatus(detail_id, "Completed", role_id);

            // 2. 如果订单状态更新成功，再更新库存
            if (statusUpdated)
            {
                return _orderDetailRepository.UpdateInventoryAfterOrder(item_id, quantity);
            }
            return false;
        }
    }
}
