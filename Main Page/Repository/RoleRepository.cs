using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Class
{
    internal class RoleRepository
        {

            private readonly string _connectionstring;

            public RoleRepository(string connectionstring)
            {
                _connectionstring = connectionstring;
            }


            public RoleModel GetRoleByID(string role_id)
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionstring].ToString()))
                {
                    con.Open();
                    string query = @"
                            SELECT * 
                            FROM role 
                            WHERE role_id = @role_id
                            AND role_status = 1";

                    using (var cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@role_id", role_id);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new RoleModel
                                {
                                    role_id = reader.GetString(0),
                                    role_password = reader.GetString(1),
                                    role = reader.GetString(2),
                                    role_name = reader.GetString(3),
                                    role_ic = reader.GetString(4),
                                    role_contact = reader.GetString(5),
                                    role_email = reader.GetString(6),
                                };
                            }
                        }
                    }
                }
                return null;
            }
            
            public RoleModel AdminGetRoleByID(string role_id)
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionstring].ToString()))
                {
                    con.Open();
                    string query = @"
                                SELECT * 
                                FROM role 
                                WHERE role_id = @role_id";

                    using (var cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@role_id", role_id);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new RoleModel
                                {
                                    role_id = reader.GetString(0),
                                    role_password = reader.GetString(1),
                                    role = reader.GetString(2),
                                    role_name = reader.GetString(3),
                                    role_ic = reader.GetString(4),
                                    role_contact = reader.GetString(5),
                                    role_email = reader.GetString(6),
                                    role_status = reader.GetInt32(7),
                                };
                            }
                        }
                    }
                }
                return null;
            }

            public List<RoleModel> GetAllRole()
            {
                List<RoleModel> RoleModels = new List<RoleModel>();

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionstring].ToString()))
                {
                    con.Open();
                    string query = @"
                    SELECT *
                    FROM role";

                    using (var cmd = new SqlCommand(query, con))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            RoleModels.Add(new RoleModel
                            {
                                role_id = reader.GetString(0),
                                role_password = reader.GetString(1),
                                role = reader.GetString(2),
                                role_name = reader.GetString(3),
                                role_ic = reader.GetString(4),
                                role_contact = reader.GetString(5),
                                role_email = reader.GetString(6),
                            });
                        }
                    }
                }
                return RoleModels;
            }

            public List<RoleModel> GetRevenueByChef()
            {
                List<RoleModel> result = new List<RoleModel>();

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionstring].ToString()))
                {
                    con.Open();
                    string query = @"
                        SELECT orders_details.role_id,
                               SUM(menu.price * orders_details.item_quantity) AS chef_revenue
                        FROM orders_details
                        LEFT JOIN menu ON  menu.item_id = orders_details.item_id
                        WHERE orders_details.role_id != ''
                        GROUP BY orders_details.role_id";

                    using (var cmd = new SqlCommand(query, con))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                result.Add(new RoleModel
                                {
                                    role_id = !reader.IsDBNull(0) ? reader.GetString(0) : "Unknown",
                                    chef_revenue = !reader.IsDBNull(1) ? reader.GetDecimal(1) : 0
                                });
                            }
                        }
                    }
                }
                return result;
            }

            public bool AddRole(RoleModel role)
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionstring].ToString()))
                {
                    con.Open();
                    string query = @"
                                INSERT INTO role (role_id, role_password, role, role_name, role_ic, role_contact, role_email)
                                VALUES ( @role_id, @password, @role, @name, @ic, @contact, @email )";

                using (var cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@role_id",role.role_id);
                    cmd.Parameters.AddWithValue("@password", role.role_password);
                    cmd.Parameters.AddWithValue("@role", role.role);
                    cmd.Parameters.AddWithValue("@name", role.role_name);
                    cmd.Parameters.AddWithValue("@ic", role.role_ic);
                    cmd.Parameters.AddWithValue("@contact", role.role_contact);
                    cmd.Parameters.AddWithValue("@email", role.role_email);
                    int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }

            public bool UpdateRole(RoleModel role,string role_id)
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionstring].ToString()))
                {
                    con.Open();
                    string query = @"
                            UPDATE role
                            SET role_name = @name,
                                role_ic = @ic,
                                role_contact = @contact,
                                role_email = @email
                            WHERE role_id = @role_id";
                    using (var cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@role_id", role_id);
                        cmd.Parameters.AddWithValue("@name", role.role_name);
                        cmd.Parameters.AddWithValue("@ic",role.role_ic);
                        cmd.Parameters.AddWithValue("@contact",role.role_contact);
                        cmd.Parameters.AddWithValue("@email", role.role_email);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }

            public bool AdminUpdateRole(RoleModel role, string role_id)
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionstring].ToString()))
                {
                    con.Open();
                    string query = @"
                                UPDATE role
                                SET role_password = @password,
                                    role = @role,
                                    role_name = @name,
                                    role_ic = @ic,
                                    role_contact = @contact,
                                    role_email = @email
                                WHERE role_id = @role_id";
                    using (var cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@role_id", role_id);
                        cmd.Parameters.AddWithValue("@password", role.role_password);
                        cmd.Parameters.AddWithValue("@role", role.role);
                        cmd.Parameters.AddWithValue("@name", role.role_name);
                        cmd.Parameters.AddWithValue("@ic", role.role_ic);
                        cmd.Parameters.AddWithValue("@contact", role.role_contact);
                        cmd.Parameters.AddWithValue("@email", role.role_email);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }

            public bool UpdatePassword(string role_id, string password)
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionstring].ToString()))
                {
                    con.Open();
                    string query = @"
                                UPDATE role
                                SET role_password = @password
                                WHERE role_id = @role_id";
                    using (var cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@role_id", role_id);
                        cmd.Parameters.AddWithValue("@password", password);   
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }

            public bool DeleteRole(string role_id)
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionstring].ToString()))
                {
                    con.Open();
                    string query = @"
                        UPDATE role
                        SET role_status = 0
                        WHERE role_id = @role_id";

                    using (var cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@role_id", role_id);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
        }
}
