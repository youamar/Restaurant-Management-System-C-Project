using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOOP
{
    internal class InventoryRepository
    {

        private readonly string _connectionString;

        public InventoryRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<InventoryModel> GetAllInventory()
        {
            List<InventoryModel> InventoryModels = new List<InventoryModel>();

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionString].ToString()))
            {
                conn.Open();
                string query = @"
                    SELECT *
                    FROM inventory";
                using (var cmd = new SqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            InventoryModels.Add(new InventoryModel
                            {
                                ingredient_id = reader.GetString(0),
                                ingredient_name = reader.GetString(1),
                                stock = reader.GetDouble(2),
                                safety_stock = reader.GetDouble(3)
                            });
                        }
                    }
                }
            }
            return InventoryModels;
        }

        public bool UpdateInventory(InventoryModel inventory, string ingredient_id)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionString].ToString()))
            {
                conn.Open();
                string query = @"
                    UPDATE inventory
                    SET stock_quantity = @stock,
                    WHERE ingredient_id = @ingredient_id";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@stock_quantity", inventory.stock);
                    cmd.Parameters.AddWithValue("@ingredient_id", ingredient_id);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
    }
}
