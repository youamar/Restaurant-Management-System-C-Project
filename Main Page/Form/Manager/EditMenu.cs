using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using AssingnemntNote;
using Main_Page.Model;
using Main_Page.Service;

namespace Main_Page
{
    public partial class EditMenu : Form
    {

        private EditMenuControl _editMenuControl;
        private List<CategoryModel> _categories;

        public EditMenu(MenuModel menuItem = null)
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            txtitemid.Enabled = false;

            LoadCategories();

            _editMenuControl = new EditMenuControl(new MenuService("VegeMeat"), menuItem);
            _editMenuControl.InitializeForm(this);
        }

        private void LoadCategories()
        {
            CategoryService categoryService = new CategoryService("VegeMeat");
            _categories = categoryService.GetAllCategory(); // 获取 category_id 和 category_name

            cmbcatogery.DataSource = _categories;
            cmbcatogery.DisplayMember = "category_name"; // 显示类别名称
            cmbcatogery.ValueMember = "category_id"; // 存储类别 ID

            // 如果有传入 menuItem，设置当前选中的类别
            if (!string.IsNullOrEmpty(Category))
            {
                cmbcatogery.SelectedValue = Category;
            }
        }


        public string ItemID
        {
            get { return txtitemid.Text; }
            set { txtitemid.Text = value; }
        }

        public string ItemName
        {
            get { return txtname.Text; }
            set { txtname.Text = value; }
        }

        public string Price
        {
            get { return txtprice.Text; }
            set { txtprice.Text = value; }
        }

        public string Description
        {
            get { return txtdescription.Text; }
            set { txtdescription.Text = value; }
        }

        public string Category
        {
            get => cmbcatogery.SelectedValue?.ToString() ?? ""; // 直接返回选中的 category_id
            set
            {
                if (_categories.Any(c => c.category_id == value))
                {
                    cmbcatogery.SelectedValue = value; // 设置选中的类别
                }
            }
        }

        public string Title
        {
            get { return lblTitle.Text; }
            set { lblTitle.Text = value; }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_editMenuControl.ConfirmChanges(this))
            {
                MessageBox.Show("Changes saved successfully!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
