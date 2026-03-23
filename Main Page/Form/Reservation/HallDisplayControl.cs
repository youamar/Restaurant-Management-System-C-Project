using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Assignmemt_inventory;
using AssingnemntNote;
using Main_Page.Model;
using Main_Page.Order;
using Main_Page.Reservation;

namespace Main_Page
{
    internal class HallDisplayControl
    {

        private Form parentForm;
        private Button[] buttons;
        private Label label;
        private PictureBox pictureBox;

        private List<HallModel> halls;
        private List<HallModel> descriptions;

        private Button _selectedButton;

        public HallDisplayControl(Form parentForm, Button[] buttons, Label label, PictureBox pictureBox)
        {
            this.parentForm = parentForm;
            this.buttons = buttons;
            this.label = label;
            this.pictureBox = pictureBox;

            descriptions = new List<HallModel>();
        }

        public HallDisplayControl(HallDisplay form)
        {
            parentForm = form;
        }

        public void LoadData()
        {
            HallService _hallService = new HallService("VegeMeat");
            halls = _hallService.GetActiveHall();

            descriptions = halls;

            BindHallToButton();

            if (halls.Count > 0)
            {
                HallModel defaulthall = halls[0];
                HallModel filteredDescription = descriptions.FirstOrDefault(f => f.hall_id == defaulthall.hall_id);
                label.Text = filteredDescription.description;

                buttons[0].PerformClick();
            }
        }

        private void BindHallToButton()
        {
            for (int i = 0; i < buttons.Length && i < halls.Count; i++)
            {
                buttons[i].Text = halls[i].name;
                buttons[i].Tag = halls[i];
                buttons[i].Click += HandleHallButtonClick;
            }
        }

        private void HandleHallButtonClick(object sender, EventArgs e)
        {
            if (sender is Button button && button.Tag is HallModel selectedHall)
            {
                if (_selectedButton != null)
                {
                    _selectedButton.BackColor = Color.MistyRose; // 默认颜色
                }

                button.BackColor = Color.LightCoral; // 选中颜色
                _selectedButton = button; // 记录当前按钮

                HallModel filteredDescription = descriptions.FirstOrDefault(f => f.hall_id == selectedHall.hall_id);

                if (filteredDescription != null)
                {
                    label.Text = filteredDescription.description;
                }

                if (selectedHall.photo != null && selectedHall.photo.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(selectedHall.photo))
                    {
                        Image img = Image.FromStream(ms);
                        pictureBox.Image = new Bitmap(img); // 避免使用 disposed 的 stream
                        pictureBox.SizeMode = PictureBoxSizeMode.StretchImage; // 显示方式
                    }
                }
            }
        }
    }
}
