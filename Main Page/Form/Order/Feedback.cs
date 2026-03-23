using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Assignmemt_inventory;

namespace Main_Page
{
    public partial class Feedback : Form
    {

        private string order_id;

        public Feedback(string order_id)
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.order_id = order_id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FeedbackControl _feedbackControl = new FeedbackControl(this, rating, txtfeedback, order_id);
            _feedbackControl.SubmitFeedback();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
