using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignmemt_inventory
{
    internal class FeedbackService
    {
        private readonly FeedbackRepository _feedbackRepository;

        public FeedbackService(string connectionString)
        {
            _feedbackRepository = new FeedbackRepository(connectionString);
        }

        public List<FeedbackModel> GetAllFeedbacks()
        {
            return _feedbackRepository.GetAllFeedbacks();
        }

        public bool AddFeedBack(string feedback_id, int rating, string content, string order_id)
        {
            var FeedbackModels = new FeedbackModel { feedback_id = feedback_id, rating = rating, content = content, order_id = order_id};
            return _feedbackRepository.AddFeedBack(FeedbackModels);
        }   
    }
}
