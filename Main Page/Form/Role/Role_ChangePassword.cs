using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main_Page.Role
{
    public partial class Role_ChangePassword : Form
    {

        private Role_ChangePassword_Control control;

        public Role_ChangePassword()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

            lblwrong.Visible = false;
            lblNoMatch.Visible = false;

            Label wrong = lblwrong;
            Label nomatch = lblNoMatch;
            control = new Role_ChangePassword_Control(this, tboldPass, tbNewPass, tbnewPass2, lblwrong, lblNoMatch);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            control.CheckPass();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
