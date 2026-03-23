using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssingnemntNote;
using Main_Page.Model;
using Main_Page.Order;
using Main_Page.Service;
using System.Windows.Forms;
using System.Diagnostics.Eventing.Reader;
using System.IO;

namespace Main_Page
{
    internal class FoodControl
    {

        private Form parentForm;

        private Label[] labels;
        private MenuModel _menuModel;
        private PictureBox pictureBox;
        
        private int quantity = 1;

        public FoodControl(Form parentForm, Label[] labels, MenuModel _menuModel, PictureBox picture)
        {
            this.parentForm = parentForm;
            this._menuModel = _menuModel;
            this.labels = labels;
            this.pictureBox = picture;
        }

        public void LoadData()
        {
            MenuService _menuService = new MenuService("VegeMeat");
            _menuModel = _menuService.GetItemByID(_menuModel.item_id);

            labels[0].Text = _menuModel.item.ToString();
            labels[1].Text = _menuModel.description.ToString();
            labels[2].Text = $"${_menuModel.price.ToString()}";

            if (_menuModel.photo != null)
            {
                using (MemoryStream ms = new MemoryStream(_menuModel.photo))
                {
                    Image img = Image.FromStream(ms);

                    pictureBox.Image = img;
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            else
            {
                pictureBox.Text = _menuModel.item_id.ToString();
            }
        }

        public void AddQuantity()
        {
            quantity += 1;
        }

        public void CutQuantity()
        {
            if (quantity > 1) quantity -= 1;
        }

        public int DisplayQuantity()
        {
            return quantity;
        }

        public void AddToCart()
        {
            CartModel item = new CartModel
            {
                item_id = _menuModel.item_id,
                item_name = _menuModel.item,
                quantity = quantity,
                item_total_price = _menuModel.price * quantity
            };

            CartControl.Instance.AddToCart(item, _menuModel);
        }
    }
}
