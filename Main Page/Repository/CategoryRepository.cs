using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Class;
using Main_Page.Model;

namespace Main_Page.Repository
{
    internal class CategoryRepository
    {
        private readonly string _connectionstring;

        public CategoryRepository(string connectionString)
        {
            _connectionstring = connectionString;
        }

        public List<CategoryModel> GetAllCategory()
        {
            List<CategoryModel> Category = new List<CategoryModel>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionstring].ToString()))
            {
                con.Open();
                string query = @"
                SELECT *
                FROM category";

                using (var cmd = new SqlCommand(query, con))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Category.Add(new CategoryModel
                        {
                            category_id = reader.GetString(0),
                            category_name = reader.GetString(1),
                        });
                    }
                }
                return Category;
            }
        }

        public List<CategoryModel> GetRevenueByCategoryID()
        {
            List<CategoryModel> Category = new List<CategoryModel>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionstring].ToString()))
            {
                con.Open();
                string query = @"
                    SELECT category.category_name,
                    SUM (menu.price * orders_details.item_quantity) AS total_revenue
                    FROM category
                    LEFT JOIN menu ON category.category_id = menu.category_id
                    LEFT JOIN orders_details on orders_details.item_id = menu.item_id
                    GROUP BY category.category_name";

                using (var cmd = new SqlCommand(query, con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Category.Add(new CategoryModel
                            {
                                category_name = reader.GetString(0),
                                category_revenue = !reader.IsDBNull(1)? reader.GetDecimal(1): 0
                            });
                        }
                    }
                }
                
                return Category;
            }
        }
    }
}
