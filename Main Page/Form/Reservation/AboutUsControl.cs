using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Assignmemt_inventory;
using IOOP;
using System.Drawing;

namespace Main_Page
{
    internal class AboutUsControl
    {
        private Form parentForm;
        private Label[] labels;

        public AboutUsControl(Form parentForm, Label[] labels)
        {
            this.parentForm = parentForm;
            this.labels = labels;
        }

        public void LoadData()
        {
            RestaurantService _restaurantService = new RestaurantService("VegeMeat");
            RestaurantModel _restaurantModel;
            _restaurantModel = _restaurantService.GetRestaurantData();

            labels[0].Text = _restaurantModel.name;
            labels[1].Text = _restaurantModel.description;
            labels[2].Text = _restaurantModel.history;
            labels[3].Text = _restaurantModel.address;
            labels[4].Text = _restaurantModel.email;
            labels[4].ForeColor = Color.Blue;
        }

    }
}
