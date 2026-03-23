using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignmemt_inventory;
using Class;

namespace Main_Page
{
    internal class MessageRepository
    {
        public readonly string _connectionString;

        public MessageRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<MessageModel> GetAllMessages()
        {
            List<MessageModel> _messageModel = new List<MessageModel>();

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionString].ToString()))
            {
                conn.Open();
                string query = @"
                        SELECT * 
                        FROM message";

                using (var cmd = new SqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            _messageModel.Add(new MessageModel
                            {
                                message_id = reader.GetString(0),
                                message = reader.GetString(1),
                                reservation_id = reader.GetString(2)
                            });
                        }
                    }
                }
            }
            return _messageModel;
        }

        public List<MessageModel> GetMessages(string customer_id)
        {
            List<MessageModel> _messageModel = new List<MessageModel>();

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionString].ToString()))
            {
                conn.Open();
                string query = @"
                        SELECT message.message_id, message.message, message.reservation_id 
                        FROM message
                        LEFT JOIN reservation ON reservation.reservation_id = message.reservation_id
                        LEFT JOIN customer ON customer.customer_id = reservation.customer_id
                        WHERE customer.customer_id = @customer_id";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@customer_id", customer_id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            _messageModel.Add(new MessageModel
                            {
                                message_id = reader.GetString(0),
                                message = reader.GetString(1),
                                reservation_id = reader.GetString(2)
                            });
                        }
                    }
                }
            }
            return _messageModel;
        }

        public bool AddMessage(MessageModel message)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionString].ToString()))
            {
                conn.Open();
                string query = @"
                    INSERT INTO message (message_id, message, reservation_id)
                    VALUES
                    (@message_id, @message, @reservation_id)";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@message_id", message.message_id);
                    cmd.Parameters.AddWithValue("@message", message.message);
                    cmd.Parameters.AddWithValue("@reservation_id", message.reservation_id);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
    }
}
