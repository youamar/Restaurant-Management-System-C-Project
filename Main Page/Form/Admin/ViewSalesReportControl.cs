using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AssingnemntNote;
using Class;
using Main_Page.Model;
using Main_Page.Service;

namespace Main_Page
{
    internal class ViewSalesReportControl
    {
        private ListBox listboxreport;
        private Button btnMonth;
        private Button btnCategory;
        private Button btnChef;

        private RoleService roleService;
        private OrderDetailService orderDetailService;
        private CategoryService categoryService;
        private MenuService menuService;
        private InvoiceService invoiceService;

        private RoleModel roleModel;
        private OrderDetailModel orderDetailModel;
        private CategoryModel categoryModel;
        private MenuModel menuModel;
        private List<InvoiceModel> invoiceModel;

        public ViewSalesReportControl(ListBox listboxreport, Button btnMonth, Button btnCategory, Button btnChef)
        {
            roleService = new RoleService("VegeMeat");
            orderDetailService = new OrderDetailService("VegeMeat");
            categoryService = new CategoryService("VegeMeat");
            menuService = new MenuService("VegeMeat");
            invoiceService = new InvoiceService("VegeMeat");

            this.listboxreport = listboxreport;
            this.btnMonth = btnMonth;
            this.btnCategory = btnCategory;
            this.btnChef = btnChef;
        }

        public string RoleName()
        {
            roleModel = roleService.GetRoleByID(SessionManager.Instance.RoleId);
            return $"{roleModel.role} {roleModel.role_name.Split(' ')[0]}";
        }

        public void LoadMonth()
        {
            int year = DateTime.Now.Year;
            listboxreport.Items.Clear();

            for (int month = 1; month <= 12; month++)
            {
                DateTime date = new DateTime(year, month, 1);

                decimal revenue = invoiceService.GetRevenueByMonth(date);

                string monthName = new DateTime(year, month, 1).ToString("MMMM");
                string formatted = $"{monthName} - RM{revenue:N2}";

                listboxreport.Items.Add(formatted);
            }

        }

        public void LoadCategory()
        {
            listboxreport.Items.Clear();

            var categoryRevenueList = categoryService.GetRevenueByCategoryID();
            foreach (var category in categoryRevenueList)
            {
                listboxreport.Items.Add($"{category.category_name} - RM{category.category_revenue:F2}");
            }
        }

        public void LoadChef()
        {
            listboxreport.Items.Clear();

            var chefRevenueList = roleService.GetRevenueByChef();
            foreach ( var chef in chefRevenueList)
            {
                listboxreport.Items.Add($"{chef.role_id} - RM{chef.chef_revenue:F2}");
            }
        }

    }
}
