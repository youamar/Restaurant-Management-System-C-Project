using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Assignmemt_inventory;

namespace Main_Page
{
    public partial class EditHall : Form
    {
        private EditHallControl _editHallControl;

        public EditHall(HallModel hall)
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

            _editHallControl = new EditHallControl(new HallService("VegeMeat"), hall);
            _editHallControl.LoadForm(txtid, txtname, txtdes, txttype, pax, lblTitle);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (_editHallControl.SaveChanges(txtid, txtname, txtdes, txttype, pax))
            {
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
