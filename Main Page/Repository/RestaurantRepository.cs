using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Assignmemt_inventory
{
    internal class RestaurantRepository
    {
        private readonly string _connectionString;

        public RestaurantRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public RestaurantModel GetRestaurantData()
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionString].ToString()))
            {
                conn.Open();
                string query = @"
                    SELECT * FROM restaurant";
                using (var cmd = new SqlCommand(query, conn)) 
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new RestaurantModel
                            {
                                restaurant_id = reader.GetString(0),
                                name = reader.GetString(1),
                                description = reader.GetString(2),
                                address = reader.GetString(3),
                                history = reader.GetString(4),
                                email = reader.GetString(5)
                            };
                        }
                    }
                }
            }
            return null;
        }
        
            
    }
}
