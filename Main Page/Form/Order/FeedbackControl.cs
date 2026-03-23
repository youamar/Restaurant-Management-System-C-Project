using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Assignmemt_inventory;

namespace Main_Page
{
    internal class FeedbackControl
    {
        private int rating;
        private string feedback;
        private string order_id;

        private Form parentForm;
        private ComboBox comboBox;
        private TextBox textBox;

        public FeedbackControl(Form parentForm, ComboBox comboBox, TextBox textBox, string order_id)
        {
            this.parentForm = parentForm;
            this.comboBox = comboBox;
            this.textBox = textBox;
            this.order_id = order_id;
        }

        public void SubmitFeedback()
        {
            if (comboBox.SelectedIndex != -1)
            {
                rating = int.Parse(comboBox.SelectedItem.ToString());

                if (textBox.Text != "")
                {
                    feedback = textBox.Text;
                    AddFeedback();
                }
                else
                {
                    MessageBox.Show("Any comments? Thanks!");
                    textBox.Focus();
                }
            }
            else
            {
                MessageBox.Show("Kindly Please Rate! XD");
                comboBox.Focus();
            }
        }

        private void AddFeedback()
        {

            FeedbackService _feedbackService = new FeedbackService("VegeMeat");
            List<FeedbackModel> feedbacks = _feedbackService.GetAllFeedbacks();

            int feedback_id = feedbacks.Count + 1; 

            if(_feedbackService.AddFeedBack($"F{feedback_id}", rating, feedback, order_id))
            {
                parentForm.Hide();
                MessageBox.Show("Thanks For Your Feedbacks!");
            }
            else
            {
                MessageBox.Show("Recored Fails");
            }
        }

    }
}
