using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOOP
{
    internal class RecipeRepository
    {
        private readonly string _connectionString;
        
        public RecipeRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<RecipeModel> GetRecipeFromItem(string item_id)
        {
            List<RecipeModel> RecipeModels = new List<RecipeModel>();

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionString].ToString()))
            {
                conn.Open();
                string query = @"
                    SELECT ingredient_id, require_quantity
                    FROM recipe
                    WHERE item_id = @item_id";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@item_id", item_id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            RecipeModels.Add(new RecipeModel
                            {
                                ingredient_id = reader.GetString(2),
                                require_quantitiy = reader.GetDouble(3)
                            });
                        }
                    }
                }
            }
            return RecipeModels;
        }
    }
}
