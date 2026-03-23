using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignmemt_inventory;
using System.Windows.Forms;
 
namespace Main_Page
{
    internal class EditHallControl
    {
        private readonly HallService _hallService;
        private HallModel _currentHall;
        private bool _isEditMode;
 
        public EditHallControl(HallService hallService, HallModel hall)
        {
            _hallService = hallService;
            _currentHall = hall;
            _isEditMode = hall != null; // 如果 hall 为空，说明是新增
        }
 
        public void LoadForm(TextBox txtid, TextBox txtname, TextBox txtdes, TextBox txttype, NumericUpDown pax, Label lblTitle)
        {
            if (_isEditMode)
            {
                // 编辑模式：填充文本框
                txtid.Text = _currentHall.hall_id;
                txtid.ReadOnly = true; // Hall ID 不能修改
                txtname.Text = _currentHall.name;
                txtdes.Text = _currentHall.description;
                txttype.Text = _currentHall.type;
                pax.Text = _currentHall.maxcapacity.ToString();
                lblTitle.Text = _currentHall.name;
            }
            else
            {
                List<HallModel> list = _hallService.GetAllHall();
                string hall_id = $"H{list.Count +1 }";

                lblTitle.Text = "Please Add a new hall details";
                txtid.Text = hall_id;
            }
        }
 
        public bool SaveChanges(TextBox txtid, TextBox txtname, TextBox txtdes, TextBox txttype, NumericUpDown pax)
        {
            if (string.IsNullOrWhiteSpace(txtname.Text) ||
                string.IsNullOrWhiteSpace(txtdes.Text) ||
                string.IsNullOrWhiteSpace(txttype.Text) ||
                string.IsNullOrWhiteSpace(pax.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            int maxPax = (int)pax.Value;
            if (maxPax <= 0)
            {
                MessageBox.Show("Approximate Pax must be greater than 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (_isEditMode)
            {
                // 更新数据库
                bool success = _hallService.UpdateHall(_currentHall.hall_id, txtname.Text, txtdes.Text, maxPax, txttype.Text, _currentHall.restaurant_id);
                if (success)
                {
                    MessageBox.Show("Hall updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Failed to update hall.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                // 新增到数据库
                bool success = _hallService.AddHall(txtid.Text, txtname.Text, txtdes.Text, maxPax, txttype.Text, "R01");
                if (success)
                {
                    MessageBox.Show("New hall added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    MessageBox.Show("Failed to add hall.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
    }
}