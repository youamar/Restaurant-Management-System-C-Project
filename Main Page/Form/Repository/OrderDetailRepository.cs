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

        public List<OrderDetailModel> GetAllOrderDetail(string detail_id)
        {
            List<OrderDetailModel> OrderDetailModels = new List<OrderDetailModel>();

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionString].ToString()))
            {
                conn.Open();
                string query = @"
                    SELECT orderDetail_id, detail_id, item_id, role_id, status, quantity
                    FROM order";

                using (var cmd = new SqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        OrderDetailModels.Add(new OrderDetailModel
                        {
                            detail_id = reader.GetString(0),
                            order_id = reader.GetString(1),
                        });
                    }
                }
            }
            return OrderDetailModels;
        }

        public bool AddOrderDetail(OrderDetailModel detail, string detail_id)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionString].ToString()))
            {
                conn.Open();
                string query = @"
                INSERT INTO detail (detail_id, item_id, role_id, status, quantity)
                VALUES
                (@detail_id, @order_id, @item_id, @role_id, @status, @quantity)";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@order_id", detail_id);
                    cmd.Parameters.AddWithValue("@order_id", detail.order_id);
                    cmd.Parameters.AddWithValue("@item_id", detail.item_id);
                    cmd.Parameters.AddWithValue("@role_id", detail.role_id);
                    cmd.Parameters.AddWithValue("@status", detail.status);
                    cmd.Parameters.AddWithValue("@quantity", detail.quantity);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;

                }
            }

        }

        public bool UpdateDetailStatus(OrderDetailModel detail, string detail_id)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionString].ToString()))
            {
                conn.Open();
                string query = @"
                    UPDATE detail
                    SET detail_id = @detail_id,
                        order_id = @order_id,
                        item_id = @item_id,
                        role_id = @role_id,
                        status = @status,
                        quantity = @quantity";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@detail_id", detail_id);
                    cmd.Parameters.AddWithValue("@order_id", detail.order_id);
                    cmd.Parameters.AddWithValue("@item_id", detail.item_id);
                    cmd.Parameters.AddWithValue("@role_id", detail.role_id);
                    cmd.Parameters.AddWithValue("@status", detail.status);
                    cmd.Parameters.AddWithValue("@quantity", detail.quantity);
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

        public List<OrderDetailModel> GetAllOrder(string detail_id)
        {
            List<OrderDetailModel> OrderDetailModels = new List<OrderDetailModel>();

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionString].ToString()))
            {
                conn.Open();
                string query = @"
                    SELECT orderDetail_id, detail_id, item_id, role_id, status, quantity
                    FROM order";

                using (var cmd = new SqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        OrderDetailModels.Add(new OrderDetailModel
                        {
                            detail_id = reader.GetString(0),
                            order_id = reader.GetString(1),
                        });
                    }
                }
            }
            return OrderDetailModels;
        }


    }
}
