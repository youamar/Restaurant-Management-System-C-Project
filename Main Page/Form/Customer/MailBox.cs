using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main_Page
{
    public partial class MailBox : Form
    {
        private Button[] buttons;

        public MailBox()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;

            buttons = new Button[] { M1, M2, M3, M4 };

            MailBoxControl _mailBoxControl = new MailBoxControl(buttons);
            _mailBoxControl.LoadData();
        }
    }
}
