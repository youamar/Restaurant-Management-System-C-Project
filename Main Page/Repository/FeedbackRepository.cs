using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace Assignmemt_inventory
{
    internal class FeedbackRepository
    {
        private readonly string _connectionString;

        public FeedbackRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<FeedbackModel> GetAllFeedbacks()
        {
            List<FeedbackModel> feedbackModels = new List<FeedbackModel>();

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionString].ToString()))
            {
                conn.Open();
                string query = @"
                    SELECT *
                    FROM feedback";

                using (var cmd = new SqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            feedbackModels.Add(new FeedbackModel
                            {
                                feedback_id = reader.GetString(0),
                                rating = reader.GetInt32(1),
                                content = reader.GetString(2),
                                order_id = reader.GetString(3),
                                date = reader.GetDateTime(4).ToString("yyyy/MM/dd")
                            });
                        }
                    }
                }
            }
            return feedbackModels;
        }

        public bool AddFeedBack(FeedbackModel feedback)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionString].ToString()))
            {
                conn.Open();
                string query = @"
                    INSERT INTO feedback (feedback_id, rating, content, order_id)
                    VALUES
                    (@feedback_id, @rating, @content, @order_id)";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@feedback_id", feedback.feedback_id);
                    cmd.Parameters.AddWithValue("@rating", feedback.rating);
                    cmd.Parameters.AddWithValue("@content", feedback.content);
                    cmd.Parameters.AddWithValue("@order_id", feedback.order_id);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

    }
}
