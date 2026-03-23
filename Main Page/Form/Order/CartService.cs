using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssingnemntNote;
using Class;

namespace Main_Page
{
    internal class CartService
    {
        private readonly OrderService _orderService;
        private readonly OrderDetailService _orderDetailService;
        private readonly InvoiceService _invoiceService;

        private string order_id;

        public CartService(OrderService orderService, OrderDetailService orderDetailService, InvoiceService invoiceService)
        {
            _orderService = orderService;
            _orderDetailService = orderDetailService;
            _invoiceService = invoiceService;
        }

        public void CheckoutCart()
        {
            Random random = new Random();
            string orderId = $"T{DateTime.Now:MMddmmss}{ random.Next(10, 99)}";
            order_id = orderId;

            List<CartModel> cartItems = CartControl.Instance.GetCart();

            _orderService.AddOrder(orderId, SessionManager.Instance.CustomerId);

            List<OrderDetailModel> orderDetails = _orderDetailService.GetAllOrder(null);
            int currentCount = orderDetails.Count;

            for (int i = 0; i < cartItems.Count; i++)
            {
                string detail_id = $"D{(currentCount + i + 1).ToString().PadLeft(3, '0')}";

                OrderDetailModel orderDetail = new OrderDetailModel
                {
                    detail_id = detail_id,
                    order_id = orderId,
                    item_id = cartItems[i].item_id,
                    quantity = cartItems[i].quantity,
                    status = "Pending",
                };

                _orderDetailService.AddOrderDetail(orderDetail);
            }

            decimal grandTotal = cartItems.Sum(item => item.item_total_price);
            string invoiceId = $"I{DateTime.Now:MMddmmss}{random.Next(100, 999)}";

            _invoiceService.AddInvoice(invoiceId, orderId, grandTotal, "paid");

            CartControl.Instance.ClearCart();
        }

        public string OrderID()
        {
            return order_id;
        }
    }
}
