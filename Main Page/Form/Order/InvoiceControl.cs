using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Assignmemt_inventory;
using AssingnemntNote;
using Class;
using Main_Page.Model;
using Main_Page.Order;

namespace Main_Page
{
    internal class InvoiceControl
    {

        private Button[] buttons;
        private ListView listView;

        private List<InvoiceModel> invoices;
        private List<OrderDetailModel> details;
        private List<MenuModel> foods;
        private List<String> strings;

        private Button _selectedButton;

        private decimal subtotal = 0;
        private string date;


        public InvoiceControl(Button[] buttons, ListView listView)
        {
            this.buttons = buttons;
            this.listView = listView;

            strings = new List<string>();

            SetupListView();
        }

        public void LoadData()
        {
            InvoiceService _invoiceService = new InvoiceService("VegeMeat");
            invoices = _invoiceService.GetInvoiceByID(SessionManager.Instance.CustomerId);
            invoices = invoices.OrderByDescending(i => i.date).ToList();

            MenuService _menuService = new MenuService("VegeMeat");
            foods = _menuService.GetAllMenu();

            BindInvoiceToButton();

            if (invoices.Count > 0)
            {
                HandleInvoiceButtonClick(buttons[0], EventArgs.Empty);
            }
        }


        private void BindInvoiceToButton()
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                if (i < invoices.Count)
                {
                    decimal total = invoices[i].amount * 1.16m;

                    buttons[i].Text = $"{invoices[i].invoice_id}\nTotal Spending: {total.ToString()}";
                    buttons[i].Visible = true;
                    buttons[i].Tag = invoices[i];

                    buttons[i].Click -= HandleInvoiceButtonClick;
                    buttons[i].Click += HandleInvoiceButtonClick;

                }
                else
                {
                    buttons[i].Visible = false;
                }
            }
        }

        private void HandleInvoiceButtonClick(object sender, EventArgs e)
        {
            if (sender is Button button && button.Tag is InvoiceModel selectedInvoice)
            {
                if (_selectedButton != null)
                {
                    _selectedButton.BackColor = Color.MistyRose; // 默认颜色
                }

                button.BackColor = Color.LightCoral; // 选中颜色
                _selectedButton = button; // 记录当前按钮

                OrderDetailService _orderDetailService = new OrderDetailService("VegeMeat");
                details = _orderDetailService.GetOrderDetailByID(selectedInvoice.order_id);

                date = selectedInvoice.date;

                if (details == null || details.Count == 0)
                {
                    MessageBox.Show("No order details found.");
                    return;
                }

                GenerateInvoiceDetails(details);
            }
        }

        private void GenerateInvoiceDetails(List<OrderDetailModel> filteredDetails)
        {
            strings.Clear();
            listView.Items.Clear();
            subtotal = 0;

            foreach (var detail in filteredDetails)
            {
                MenuModel foodItem = foods.FirstOrDefault(f => f.item_id == detail.item_id);

                if (foodItem != null)
                {
                    decimal totalPrice = foodItem.price * detail.quantity;
                    subtotal += totalPrice; // 计算总价

                    // 添加到 ListView
                    ListViewItem item = new ListViewItem(detail.quantity.ToString()); // 第一列：食物名称
                    item.SubItems.Add(foodItem.item); // 第二列：数量
                    item.SubItems.Add(totalPrice.ToString("F2")); // 第三列：总价

                    listView.Items.Add(item);
                }
            }

            // 计算额外费用
            decimal serviceCharge = subtotal * 0.10m;
            decimal sst = subtotal * 0.06m;
            decimal grandTotal = subtotal + serviceCharge + sst;

            // 添加分隔线（可以用空字符串或者 "---------" ）
            listView.Items.Add(new ListViewItem(new string[] { "", "", "" }));
            listView.Items.Add(new ListViewItem(new string[] { "", "", "" }));
            listView.Items.Add(new ListViewItem(new string[] { "", "", "" }));
            listView.Items.Add(new ListViewItem(new string[] { "---", "--------------------------", "-----" }));
            listView.Items.Add(new ListViewItem(new string[] { "", "Subtotal", subtotal.ToString("F2") }));
            listView.Items.Add(new ListViewItem(new string[] { "", "Service Charge (10%)", serviceCharge.ToString("F2") }));
            listView.Items.Add(new ListViewItem(new string[] { "", "SST (6%)", sst.ToString("F2") }));
            listView.Items.Add(new ListViewItem(new string[] { "", "Grand Total", grandTotal.ToString("F2") }));
            listView.Items.Add(new ListViewItem(new string[] { "---", $"------**{date}**------", "-----" }));

        }

        private void SetupListView()
        {
            listView.View = View.Details;
            listView.Columns.Clear();

            listView.Columns.Add("QTY", 30, HorizontalAlignment.Left);   // 食物名称
            listView.Columns.Add("ITEM", 170, HorizontalAlignment.Left); // 数量
            listView.Columns.Add("RM", 48, HorizontalAlignment.Right); // 价格
        }
    }
}
