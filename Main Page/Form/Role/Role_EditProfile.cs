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

namespace Main_Page
{
    public partial class Role_EditProfile : Form
    {

        private Role_EditProfile_Control control;

        public Role_EditProfile()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

            control = new Role_EditProfile_Control(this, tbname, tbcontact, tbic, tbemail);
            control.LoadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            control.Update();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Role_Profile profile = new Role_Profile();
            profile.Show();
            this.Hide();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
