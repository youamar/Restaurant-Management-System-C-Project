using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AssingnemntNote;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Main_Page.Order
{
    public partial class Food : Form
    {
        private MenuModel selectedfood;
        private FoodControl foodControl;
        private Menu _menuForm;

        private Label[] labels;

        internal Food(Menu menu, MenuModel selectedfood, CartControl _cartControl)
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.selectedfood = selectedfood;
            this._menuForm = menu;

            Label[] labels = { item, description, price };

            foodControl = new FoodControl(this, labels, selectedfood, picture);
            foodControl.LoadData();

            quantity.Text = $"{1}";
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Menu obj1 = new Menu();
            obj1.Show();
            this.Hide();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            foodControl.CutQuantity();
            quantity.Text = $"{foodControl.DisplayQuantity()}";
        }

        private void brn2_Click(object sender, EventArgs e)
        {
            foodControl.AddQuantity();
            quantity.Text = $"{foodControl.DisplayQuantity()}";
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            foodControl.AddToCart();
            _menuForm.Show();
            this.Close();
        }
    }
}
