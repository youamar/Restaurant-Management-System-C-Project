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

        public MenuModel GetItemByID(string item_id)
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
                            return new MenuModel
                            {
                                item_id = reader.GetString(0),
                                category_id = reader.GetString(1),
                            };
                        }
                    }

                }
            }
            return null;
        }

        public List<MenuModel> GetAllMenu(string item_id)
        {
            List<MenuModel> MenuModels = new List<MenuModel>();

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionString].ToString()))
            {
                conn.Open();
                string query = @"
                    SELECT item_id, item, description, price, category_id, categoryname
                    FROM menu";

                using (var cmd = new SqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        MenuModels.Add(new MenuModel
                        {
                            item_id = reader.GetString(0),
                            category_id = reader.GetString(4),
                        });
                    }
                }
            }
            return MenuModels;
        }

        public bool AddItem(MenuModel menu, string item_id)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionString].ToString()))
            {
                conn.Open();
                string query = @"
                INSERT INTO menu (item_id, item, description, price, category_id, categoryname)
                VALUES
                (@item_id, @item, @description, @price, @category_id, @categoryname)";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@item_id", item_id);
                    cmd.Parameters.AddWithValue("@item", menu.item);
                    cmd.Parameters.AddWithValue("@description", menu.description);
                    cmd.Parameters.AddWithValue("@price", menu.price);
                    cmd.Parameters.AddWithValue("@category_id", menu.category_id);
                    cmd.Parameters.AddWithValue("@categoryname", menu.categoryname);
                    cmd.Parameters.AddWithValue("@sales", menu.sales);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;

                }
            }

        }

        public bool UpdateItem(MenuModel menu, string item_id)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionString].ToString()))
            {
                conn.Open();
                string query = @"
                    UPDATE menu
                    SET item_id = @item_id,
                        item = @item,
                        description = @description,
                        price = @price,
                        category_id = @category_id,
                        categoryname = @categoryname,
                        sales = @sales,
                        WHERE item_id = @item_id";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@item_id", item_id);
                    cmd.Parameters.AddWithValue("@item", menu.item);
                    cmd.Parameters.AddWithValue("@description", menu.description);
                    cmd.Parameters.AddWithValue("@price", menu.price);
                    cmd.Parameters.AddWithValue("@category_id", menu.category_id);
                    cmd.Parameters.AddWithValue("@categoryname", menu.categoryname);
                    cmd.Parameters.AddWithValue("@sales", menu.sales);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;

                }
            }
        }

        public bool DeleteItem(MenuModel menu, string item_id)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionString].ToString()))
            {
                conn.Open();
                string query = @"
                    DELETE FROM menu
                    WHERE item_id = @item_id";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@item_id", item_id);
                    cmd.Parameters.AddWithValue("@item", menu.item);
                    cmd.Parameters.AddWithValue("@description", menu.description);
                    cmd.Parameters.AddWithValue("@price", menu.price);
                    cmd.Parameters.AddWithValue("@category_id", menu.category_id);
                    cmd.Parameters.AddWithValue("@categoryname", menu.categoryname);
                    cmd.Parameters.AddWithValue("@sales", menu.sales);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;

                }
            }
        }

        public List<MenuModel> GetAllItemWithSales(string item_id)
        {
            List<MenuModel> MenuModels = new List<MenuModel>();

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionString].ToString()))
            {
                conn.Open();
                string query = @"
                    SELECT item_id, item, description, price, category_id, categoryname
                    FROM menu
                    WHERE menu.item_id = @item_id
                    AND menu.sales = @sales";

                using (var cmd = new SqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        MenuModels.Add(new MenuModel
                        {
                            item_id = reader.GetString(0),
                            sales = reader.GetInt32(6),
                        });
                    }
                }
            }
            return MenuModels;
        }
    }
}
