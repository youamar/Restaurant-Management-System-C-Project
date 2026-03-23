using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AssingnemntNote;
using Main_Page.Order;

namespace Main_Page
{
    internal class OrderStatusControl
    {
        private OrderDetailService _orderDetailService;
        private MenuService _menuService;

        private Form parentForm;
        private ListBox listbox;

        public OrderStatusControl(Form parentForm, ListBox listbox)
        {
            _orderDetailService = new OrderDetailService("vegeMeat");
            _menuService = new MenuService("VegeMeat");

            this.listbox = listbox;
            this.parentForm = parentForm;
        }

        public void LoadOrderStatus()
        {
            listbox.Items.Clear();

            List<OrderDetailModel> lists = _orderDetailService.GetStatusbyIncompleteInvoice(SessionManager.Instance.CustomerId);
            List<MenuModel> menus = _menuService.GetAllMenu();

            if (lists.Count == 0)
            {
                MessageBox.Show("No Orders Yet!");
                parentForm.Hide();
                return;
            }

            foreach (OrderDetailModel detail in lists)
            {
                string itemName = menus.FirstOrDefault(m => m.item_id == detail.item_id)?.item ?? "Unknown Item";

                listbox.Items.Add($"{detail.quantity}x {itemName}");
                listbox.Items.Add($"- {detail.status}");
            }
        }
    }
}
