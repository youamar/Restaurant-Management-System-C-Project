using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Assignmemt_inventory
{
    internal class HallRepository
    {

        private readonly string _connectionString;

        public HallRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public HallModel GetHallByID(string hall_id)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["VegeMeat"].ToString()))
            {
                conn.Open();
                string query = @"
                    SELECT *
                    FROM hall
                    WHERE hall.hall_id = @hall_id";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@hall_id", hall_id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new HallModel
                            {
                                hall_id = reader.GetString(0),
                                name = reader.GetString(1),
                                description = reader.GetString(2),
                                maxcapacity = reader.GetInt32(3),
                                type = reader.GetString(4),
                                restaurant_id = reader.GetString(5)
                            };
                        }
                    }
                }
            }
            return null;
        }

        public HallModel GetHallNameByID(string hall_id)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["VegeMeat"].ToString()))
            {
                conn.Open();
                string query = @"
                    SELECT hall_name
                    FROM hall
                    WHERE hall.hall_id = @hall_id";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@hall_id", hall_id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new HallModel
                            {
                                name = reader.GetString(0),
                            };
                        }
                    }
                }
            }
            return null;
        }

        public List<HallModel> GetAllHall()
        {
            List<HallModel> HallModels = new List<HallModel>();

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["VegeMeat"].ToString()))
            {
                conn.Open();
                string query = @"
                    SELECT *
                    FROM hall";

                using (var cmd = new SqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            HallModels.Add(new HallModel
                            {
                                hall_id = reader.GetString(0),
                                name = reader.GetString(1),
                                description = reader.GetString(2),
                                maxcapacity = reader.GetInt32(3),
                                type = reader.GetString(4),
                                restaurant_id = reader.GetString(5),
                                is_active = reader.GetInt32(7)
                            });
                        }
                    }
                }
            }
            return HallModels;
        }

        public List<HallModel> GetActiveHall()
        {
            List<HallModel> HallModels = new List<HallModel>();

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["VegeMeat"].ToString()))
            {
                conn.Open();
                string query = @"
                    SELECT *
                    FROM hall
                    WHERE is_active = 1";

                using (var cmd = new SqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            byte[] photoData = reader["photo"] != DBNull.Value ? (byte[])reader["photo"] : null;

                            HallModels.Add(new HallModel
                            {
                                hall_id = reader.GetString(0),
                                name = reader.GetString(1),
                                description = reader.GetString(2),
                                maxcapacity = reader.GetInt32(3),
                                type = reader.GetString(4),
                                restaurant_id = reader.GetString(5),
                                is_active = reader.GetInt32(7),
                                photo = photoData
                            });
                        }
                    }
                }
            }
            return HallModels;
        }

        public bool AddHall(HallModel hall)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["VegeMeat"].ToString()))
            {
                conn.Open();
                string query = @"
                    INSERT INTO hall (hall_id, hall_name, hall_description, approximate_capacity, party_type, restaurant_id)
                    VALUES (@hall_id, @name, @description, @maxcapacity, @type, @restaurant_id)";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@hall_id", hall.hall_id);
                    cmd.Parameters.AddWithValue("@name", hall.name);
                    cmd.Parameters.AddWithValue("@description", hall.description);
                    cmd.Parameters.AddWithValue("@maxcapacity", hall.maxcapacity);
                    cmd.Parameters.AddWithValue("@type", hall.type);
                    cmd.Parameters.AddWithValue("@restaurant_id", hall.restaurant_id);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return (rowsAffected > 0);
                }

            }
        }

        public bool UpdateHall(HallModel hall, string hall_id)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["VegeMeat"].ToString()))
            {
                conn.Open();
                string query = @"
                    UPDATE hall
                    SET hall_id = @hall_id,
                        hall_name = @name,
                        hall_description = @description,
                        approximate_capacity = @capacity,
                        party_type = @type,
                        restaurant_id = @restaurant_id
                    WHERE hall_id = @hall_id";
                
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@hall_id", hall_id);
                    cmd.Parameters.AddWithValue("@name", hall.name);
                    cmd.Parameters.AddWithValue("@description", hall.description);
                    cmd.Parameters.AddWithValue("@capacity", hall.maxcapacity);
                    cmd.Parameters.AddWithValue("@type", hall.type);
                    cmd.Parameters.AddWithValue("@restaurant_id", hall.restaurant_id);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return (rowsAffected > 0);
                }
            }
        }

        public bool HallStatus(string hall_id, int is_active)
        {
            using(var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["VegeMeat"].ToString()))
            {
                conn.Open();
                string query = @"
                    UPDATE hall
                    SET is_active = @is_active
                    WHERE hall_id = @hall_id";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@hall_id", hall_id);
                    cmd.Parameters.AddWithValue("@is_active", is_active);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return (rowsAffected > 0);
                }

            }
        }


    }
}
