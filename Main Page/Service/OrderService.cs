using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssingnemntNote
{
    internal class OrderService
    {
        private readonly OrderRepository _orderRepository;

        public OrderService(string connectionString)
        {
            _orderRepository = new OrderRepository(connectionString);
        }

        public OrderModel GetOrderByOrderID(string order_id)
        {
            return _orderRepository.GetOrderByOrderID(order_id);
        }

        public void AddOrder(string orderId, string customerId)
        {
            OrderModel order = new OrderModel
            {
                order_id = orderId,
                customer_id = customerId
            };

            _orderRepository.AddOrder(order);
        }

    }


}
