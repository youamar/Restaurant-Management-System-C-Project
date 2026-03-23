using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignmemt_inventory;
using System.Windows.Forms;
using Class;

namespace Main_Page
{
    internal class ViewFeedbackControl
    {
        private readonly FeedbackService feedbackService;
        private List<FeedbackModel> feedbacklist;
        private RoleService _roleService;
        private RoleModel _roleModel;

        private ListBox listBox1;
        private Label lblfeedback;
        private Label lblrating;

        public ViewFeedbackControl(ListBox listBox1, Label lblfeedback, Label lblrating)
        {
            List<FeedbackModel> feedbackModels = new List<FeedbackModel>();
            feedbackService = new FeedbackService("VegeMeat");
            _roleService = new RoleService("VegeMeat");

            this.listBox1 = listBox1;
            this.lblfeedback = lblfeedback;
            this.lblrating = lblrating;
        }

        public string RoleName()
        {
            _roleModel = _roleService.GetRoleByID(SessionManager.Instance.RoleId);
            return $"{_roleModel.role} {_roleModel.role_name.Split(' ')[0]}";
        }

        public void LoadFeedback()
        {
            feedbacklist = feedbackService.GetAllFeedbacks();
            
            foreach (FeedbackModel feedback in feedbacklist)
            {
                listBox1.Items.Add($"{feedback.feedback_id} - {feedback.date}");
            }
        }

        public void GetSelectedFeedback()
        {
            if (listBox1.SelectedIndex == -1) return;
            var feedback = feedbacklist[listBox1.SelectedIndex];

            lblfeedback.Text = feedback.content;
            lblrating.Text = $"Rating : {feedback.rating}.0";
        }
    }
}
