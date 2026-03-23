using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    string query = @"SELECT * FROM roles where role_id = @role_id";

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
                                };
                            }
                        }
                    }
                }
                return null;
            }
            public bool AddRole(RoleModel role, string role_id)
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionstring].ToString()))
                {
                    con.Open();
                    string query = @"INSERT INTO roles(role_id, role_password, role, role_name,role_ic,role_contact
                    VALUES (@role_id,@password,@role,@name,@ic,@contact)";
                    using (var cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@role_id", role_id);
                        cmd.Parameters.AddWithValue("@password",role.role_password );
                        cmd.Parameters.AddWithValue("@role",role.role );
                        cmd.Parameters.AddWithValue("@name", role.role_name);
                        cmd.Parameters.AddWithValue("@ic",role.role_ic );
                        cmd.Parameters.AddWithValue("@contact", role.role_contact);
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
                    string query = @"UPDATE roles
                    set role_contact = @contact
                    WHERE role_id = @role_id";
                    using (var cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@role_id", role_id);
                        cmd.Parameters.AddWithValue("@contact",role.role_contact );
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            public List<RoleModel> GetAllRoleID()
            {
                List<RoleModel> RoleModels = new List<RoleModel>();

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionstring].ToString()))
                {
                    con.Open();
                    string query = @"
                    SELECT role_id
                    FROM roles";

                    using (var cmd = new SqlCommand(query, con))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            RoleModels.Add(new RoleModel
                            {
                                role_id = reader.GetString(0),
                            });
                        }
                    }
                }
                return RoleModels;
            }
            public bool DeleteRole(string role_id)
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionstring].ToString()))
                {
                    con.Open();
                    string query = @"
                        DELETE 
                        FROM roles 
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
