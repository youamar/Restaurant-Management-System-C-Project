using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AssingnemntNote;
using Class;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;


namespace Main_Page
{
    internal class CartControl
    {

        private static CartControl _instance;
        private List<CartModel> cart;
        private CartModel _cartmodel;

        private string order_id;

        private CartControl()
        {
            cart = new List<CartModel>();
        }

        public static CartControl Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CartControl();
                }
                return _instance;
            }
        }

        public bool EmptyCart()
        {
            if (cart == null || cart.Count == 0)
            {
                return true;
            }
            return false;
        }

        public void AddToCart(CartModel _cartModel, MenuModel _menuModel)
        {
            var existingItem = cart.FirstOrDefault(x => x.item_id == _cartModel.item_id);
            if (existingItem != null)
            {
                existingItem.quantity += _cartModel.quantity;
                existingItem.item_total_price = _menuModel.price * existingItem.quantity;
            }
            else
            {
                _cartModel.Item = _menuModel;
                _cartModel.item_total_price = _menuModel.price * _cartModel.quantity;
                cart.Add(_cartModel);
            }
            CalculateTotalPrice();
        }

        public List<CartModel> GetCart()
        {
            return cart;
        }

        public void IncreaseQuantity(int item_id)
        {
            var cartItem = cart.FirstOrDefault(ci => ci.item_id == item_id);
            if (cartItem != null)
            {
                cartItem.quantity++;
                cartItem.item_total_price = cartItem.Item.price * cartItem.quantity;
            }
            CalculateTotalPrice();
        }

        public void DecreaseQuantity(int item_id)
        {
            var cartItem = cart.FirstOrDefault(ci => ci.item_id == item_id);
            if (cartItem != null)
            {
                if (cartItem.quantity > 1)
                {
                    cartItem.quantity--;
                    cartItem.item_total_price = cartItem.Item.price * cartItem.quantity;
                }
                else
                {
                    cart.Remove(cartItem);
                }
                CalculateTotalPrice();
            }
        }

        public void RemoveItem(int item_id)
        {
            cart.RemoveAll(ci => ci.item_id == item_id);
            CalculateTotalPrice();
        }

        private void CalculateTotalPrice()
        {
            if (_cartmodel == null)
            {
                _cartmodel = new CartModel(); // 先初始化
            }
            _cartmodel.sub_total_price = 0; // 先清空小计

            foreach (var item in cart)
            {
                _cartmodel.sub_total_price += item.item_total_price; // 直接累加
            }

            // 计算税费
            _cartmodel.service_change = _cartmodel.sub_total_price * 0.1m; // 10% 服务费
            _cartmodel.sst = _cartmodel.sub_total_price * 0.06m; // 6% SST
            _cartmodel.grand_total = _cartmodel.sub_total_price + _cartmodel.service_change + _cartmodel.sst;
        }

        public List<string> DisplayPrices()
        {
            return new List<string>
            {
                "",
                "-----------------------------------------------------------------------------------",
                $"Subtotal : {_cartmodel.sub_total_price:F2}",
                $"Service Charge 10% : {_cartmodel.service_change:F2}",
                $"SST 6% : {_cartmodel.sst:F2}",
                $"Grand Total : {_cartmodel.grand_total:F2}"
            };
        }

        public void GenerateOrderAndInvoice()
        {
            CartService _cartService = new CartService(new OrderService("VegeMeat"), new OrderDetailService("VegeMeat"), new InvoiceService("VegeMeat"));
            _cartService.CheckoutCart();

            order_id = _cartService.OrderID();

        }

        public void ClearCart()
        {
            cart.Clear();
        }

        public string TotalPaid()
        {
            return $"Receive Amount : {_cartmodel.grand_total:F2}";
        }

        public string OrderID()
        {
            return order_id;
        }
    }
}
