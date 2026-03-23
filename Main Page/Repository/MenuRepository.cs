using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace AssingnemntNote
{
    internal class MenuRepository
    {
        private readonly string _connectionString;

        public MenuRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public MenuModel GetItemByID(int item_id)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionString].ToString()))
            {
                conn.Open();
                string query = @"
                    SELECT *
                    FROM menu  
                    WHERE menu.item_id = @item_id";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@item_id", item_id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            byte[] photoData = reader["photo"] != DBNull.Value ? (byte[])reader["photo"] : null;

                            return new MenuModel
                            {
                                item_id = reader.GetInt32(0),
                                item = reader.GetString(1),
                                description = reader.GetString(2),
                                price = reader.GetDecimal(3),
                                category_id = reader.GetString(4),
                                is_active = reader.GetInt32(5),
                                photo = photoData
                            };
                        }
                    }
                }
            }
            return null;
        }

        public List<MenuModel> GetAllMenu()
        {
            List<MenuModel> MenuModels = new List<MenuModel>();

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionString].ToString()))
            {
                conn.Open();
                string query = @"
                    SELECT *
                    FROM menu";

                using (var cmd = new SqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        MenuModels.Add(new MenuModel
                        {
                            item_id = reader.GetInt32(0),
                            item = reader.GetString(1),
                            description = reader.GetString(2),
                            price = reader.GetDecimal(3),
                            category_id = reader.GetString(4),
                            is_active = reader.GetInt32(5)
                        });
                    }
                }
            }
            return MenuModels;
        }

        public List<MenuModel> GetActiveMenu()
        {
            List<MenuModel> MenuModels = new List<MenuModel>();

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionString].ToString()))
            {
                conn.Open();
                string query = @"
                    SELECT *
                    FROM menu
                    WHERE is_active = 1";

                using (var cmd = new SqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        byte[] photoData = reader["photo"] != DBNull.Value ? (byte[])reader["photo"] : null;

                        MenuModels.Add(new MenuModel
                        {
                            item_id = reader.GetInt32(0),
                            item = reader.GetString(1),
                            description = reader.GetString(2),
                            price = reader.GetDecimal(3),
                            category_id = reader.GetString(4),
                            is_active = reader.GetInt32(5),
                            photo = photoData
                        });
                    }
                }
            }
            return MenuModels;
        }

        public bool AddItem(MenuModel menu, int item_id)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionString].ToString()))
            {
                conn.Open();
                string query = @"
                INSERT INTO menu (item_id, item_name, item_description, price, category_id)
                VALUES
                (@item_id, @item, @description, @price, @category_id)";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@item_id", item_id);
                    cmd.Parameters.AddWithValue("@item", menu.item);
                    cmd.Parameters.AddWithValue("@description", menu.description);
                    cmd.Parameters.AddWithValue("@price", menu.price);
                    cmd.Parameters.AddWithValue("@category_id", menu.category_id);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;

                }
            }

        }

        public bool UpdateItem(MenuModel menu, int item_id)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionString].ToString()))
            {
                conn.Open();
                string query = @"
                    UPDATE menu
                    SET item_name = @item,
                        item_description = @description,
                        price = @price,
                        category_id = @category_id
                        WHERE item_id = @item_id";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@item_id", item_id);
                    cmd.Parameters.AddWithValue("@item", menu.item);
                    cmd.Parameters.AddWithValue("@description", menu.description);
                    cmd.Parameters.AddWithValue("@price", menu.price);
                    cmd.Parameters.AddWithValue("@category_id", menu.category_id);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;

                }
            }
        }

        public bool ItemStatus(int item_id, int is_active)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionString].ToString()))
            {
                conn.Open();
                string query = @"
                    UPDATE menu
                    SET is_active = @is_active
                    WHERE item_id = @item_id";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@item_id", item_id);
                    cmd.Parameters.AddWithValue("@is_active", is_active);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;

                }
            }
        }
    }
}
