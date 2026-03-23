using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssingnemntNote
{
    internal class OrderDetailRepository
    {

        private readonly string _connectionString;

        public OrderDetailRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<OrderDetailModel> GetOrderDetailByID(string order_id)
        {
            List<OrderDetailModel> OrderDetailModels = new List<OrderDetailModel>();

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionString].ToString()))
            {
                conn.Open();
                string query = @"
                    SELECT item_id, item_quantity, detail_status
                    FROM orders_details
                    WHERE order_id = @order_id";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@order_id", order_id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            OrderDetailModels.Add(new OrderDetailModel
                            {
                                item_id = reader.GetInt32(0),
                                quantity = reader.GetInt32(1),
                                status = reader.GetString(2)
                            });
                        }
                    }
                }
            }
            return OrderDetailModels;
        }

        public List<OrderDetailModel> GetStatusbyIncompleteInvoice(string customer_id)
        {
            List<OrderDetailModel> OrderDetailModels = new List<OrderDetailModel>();

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionString].ToString()))
            {
                conn.Open();
                string query = @"
                    SELECT 
                        orders_details.item_id,
                        SUM(orders_details.item_quantity) AS total_quantity,
                        orders_details.detail_status
                    FROM orders_details
                    INNER JOIN orders ON orders.order_id = orders_details.order_id
                    INNER JOIN invoice ON invoice.order_id = orders.order_id
                    WHERE 
                        orders.customer_id = @customer_id
                        AND invoice.invoice_status != 'Completed'
                    GROUP BY 
                        orders_details.item_id,
                        orders_details.detail_status";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@customer_id", customer_id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            OrderDetailModels.Add(new OrderDetailModel
                            {
                                item_id = reader.GetInt32(0),
                                quantity = reader.GetInt32(1),
                                status = reader.GetString(2)
                            });
                        }
                    }
                }
            }
            return OrderDetailModels;
        }

        public List<OrderDetailModel> GetAllOrder(string detail_id)
        {
            List<OrderDetailModel> OrderDetailModels = new List<OrderDetailModel>();

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionString].ToString()))
            {
                conn.Open();
                string query = @"
                    SELECT detail_id, order_id, item_id, role_id, detail_status, item_quantity
                    FROM orders_details";

                if(!string.IsNullOrEmpty(detail_id))
                {
                    query += " WHERE detail_id = @detail_id";
                }

                using (var cmd = new SqlCommand(query, conn))
                {
                    if (!string.IsNullOrEmpty(detail_id))
                    {
                        cmd.Parameters.AddWithValue("@detail_id", detail_id);
                    }

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            OrderDetailModels.Add(new OrderDetailModel
                            {
                                detail_id = reader.GetString(0),
                                order_id = reader.GetString(1),
                                item_id = reader.GetInt32(2),
                                role_id = reader.IsDBNull(3) ? null : reader.GetString(3),
                                status = reader.GetString(4),
                                quantity = reader.GetInt32(5)
                            });
                        }
                    }
                }
            }
            return OrderDetailModels;
        }

        public bool AddOrderDetail(OrderDetailModel detail)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionString].ToString()))
            {
                conn.Open();
                string query = @"
                INSERT INTO orders_details (detail_id, order_id, item_id, item_quantity, detail_status)
                VALUES
                (@detail_id, @order_id, @item_id, @item_quantity, @detail_status)";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@detail_id", detail.detail_id);
                    cmd.Parameters.AddWithValue("@order_id", detail.order_id);
                    cmd.Parameters.AddWithValue("@item_id", detail.item_id);
                    cmd.Parameters.AddWithValue("@item_quantity", detail.quantity);
                    cmd.Parameters.AddWithValue("@detail_status", detail.status);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public bool UpdateOrderStatus(string detail_id, string newstatus, string role_id)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionString].ToString()))
            {
                conn.Open();
                string query = @"
                    UPDATE orders_details
                    SET detail_status = @status,
                        role_id = @role_id
                    WHERE detail_id = @detail_id";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@detail_id", detail_id);
                    cmd.Parameters.AddWithValue("@status", newstatus);
                    cmd.Parameters.AddWithValue("@role_id", role_id);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public bool UpdateRole(OrderDetailModel detail, string detail_id)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionString].ToString()))
            {
                conn.Open();
                string query = @"
                    UPDATE detail
                    SET order_id = order_id,
                        role_id = role_id";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@order_id", detail.order_id);
                    cmd.Parameters.AddWithValue("@role_id", detail.role_id);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;

                }
            }
        }

        public bool UpdateInventoryAfterOrder(int item_id, int quantity)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionString].ToString()))
            {
                conn.Open();

                string query = @"
                UPDATE Inventory 
                SET stock_quantity = stock_quantity - (r.require_quantity * @quantity)
                FROM Recipe r
                JOIN Inventory i ON r.ingredient_id = i.ingredient_id
                WHERE r.item_id = @item_id";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@item_id", item_id);
                    cmd.Parameters.AddWithValue("@quantity", quantity);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
    }
}
