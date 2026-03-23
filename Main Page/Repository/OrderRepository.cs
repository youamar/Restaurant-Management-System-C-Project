using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssingnemntNote
{
    internal class OrderRepository
    {

        private readonly string _connectionString;

        public OrderRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public OrderModel GetOrderByOrderID(string order_id)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionString].ToString()))
            {
                conn.Open();
                string query = @"
                    SELECT *
                    FROM order  
                    WHERE order.order_id = @order_id";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@order_id", order_id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new OrderModel
                            {
                                order_id = reader.GetString(0),
                                customer_id = reader.GetString(1),
                                table_number = reader.GetInt32(2),
                            };
                        }
                    }

                }
            }
            return null;
        }



        public bool AddOrder(OrderModel order)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionString].ToString()))
            {
                conn.Open();
                string query = @"
                INSERT INTO orders (order_id, customer_id)
                VALUES
                (@order_id, @customer_id)";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@order_id", order.order_id);
                    cmd.Parameters.AddWithValue("@customer_id", order.customer_id);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }

        }

    }
}
    

