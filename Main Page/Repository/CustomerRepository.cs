using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Class
{
    internal class CustomerRepository
    {
        private readonly string _connectionstring;
        public CustomerRepository(string connectionstring)
        {
            _connectionstring = connectionstring;
        }

        public CustomerModel GetCustomerByContact(string contact)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionstring].ToString()))
            {
                con.Open();
                string query = @"
                        SELECT * 
                        FROM customer 
                        WHERE customer_contact = @customer_contact";

                using (var cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@customer_contact", contact);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new CustomerModel
                            {
                                customer_id = reader.IsDBNull(0) ? null : reader.GetString(0),
                                contact = reader.IsDBNull(1) ? null : reader.GetString(1),
                                name = reader.IsDBNull(2) ? null : reader.GetString(2),
                                birthday = reader.IsDBNull(3) ? null : reader.GetString(3),
                                email = reader.IsDBNull(4) ? null : reader.GetString(4)
                            };
                        }
                    }
                }
                return null;
            }
        }

        public CustomerModel GetCustomerByCustomerId(string customer_id)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionstring].ToString()))
            {
                con.Open();
                string query = @"
                        SELECT * 
                        FROM customer 
                        WHERE customer_id = @customer_id";

                using (var cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@customer_id", customer_id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new CustomerModel
                            {
                                customer_id = reader.IsDBNull(0) ? null : reader.GetString(0),
                                contact = reader.IsDBNull(1) ? null : reader.GetString(1),
                                name = reader.IsDBNull(2) ? null : reader.GetString(2),
                                birthday = reader.IsDBNull(3) ? null : reader.GetString(3),
                                email = reader.IsDBNull(4) ? null : reader.GetString(4)
                            };
                        }
                    }
                }
                return null;
            }
        }

        public bool AddCustomer(CustomerModel customer)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionstring].ToString()))
            {
                con.Open();
                string query = @"
                        INSERT INTO customer(customer_id, customer_contact)
                        VALUES (@customer_id, @customer_contact)";
                using(var cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@customer_id", customer.customer_id);
                    cmd.Parameters.AddWithValue("@customer_contact", customer.contact);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public bool AddCustomerProfile(CustomerModel customer)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionstring].ToString()))
            {
                con.Open();
                string query = @"
                        INSERT INTO customer(customer_id, customer_contact, customer_name, customer_birthday, customer_email)
                        VALUES (@customer_id, @customer_contact, @customer_name, @customer_birthday, @customer_email)";
                using (var cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@customer_id", customer.customer_id);
                    cmd.Parameters.AddWithValue("@customer_contact", customer.contact);
                    cmd.Parameters.AddWithValue("@customer_name", customer.name);
                    cmd.Parameters.AddWithValue("@customer_birthday", customer.birthday);
                    cmd.Parameters.AddWithValue("@customer_email", customer.email);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public bool UpdateCustomer(CustomerModel customer, string customer_id)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionstring].ToString()))
            {
                con.Open();
                string query = @"
                        UPDATE customer
                        set customer_contact = @customer_contact, customer_name = @customer_name, customer_email = @customer_email, customer_birthday = @customer_birthday
                        WHERE customer_id = @customer_id";

                using (var cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@customer_id", customer_id);
                    cmd.Parameters.AddWithValue("@customer_contact", customer.contact);
                    cmd.Parameters.AddWithValue("@customer_name", customer.name);
                    cmd.Parameters.AddWithValue("@customer_email", customer.email);
                    cmd.Parameters.AddWithValue("@customer_birthday", customer.birthday);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public List<CustomerModel> GetAllCustomerContact()
        {
            List<CustomerModel> CustomerModels = new List<CustomerModel>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionstring].ToString()))
            {
                con.Open();
                string query = @"
                SELECT *
                FROM customer
                WHERE customer_status = 1";

                using (var cmd = new SqlCommand(query,con))
                {
                    using(var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CustomerModels.Add(new CustomerModel
                            {
                                customer_id = reader.IsDBNull(0) ? null : reader.GetString(0),
                                contact = reader.IsDBNull(1) ? null : reader.GetString(1),
                                name = reader.IsDBNull(2) ? null : reader.GetString(2),
                                birthday = reader.IsDBNull(3) ? null : reader.GetString(3),
                                email = reader.IsDBNull(4) ? null : reader.GetString(4)
                            });
                        }
                    }
                }
                
                return CustomerModels;
            }
        }

        public List<CustomerModel> GetAllCustomer()
        {
            List<CustomerModel> CustomerModels = new List<CustomerModel>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionstring].ToString()))
            {
                con.Open();
                string query = @"
                SELECT *
                FROM customer";

                using (var cmd = new SqlCommand(query, con))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            CustomerModels.Add(new CustomerModel
                            {
                                customer_id = reader.IsDBNull(0) ? null : reader.GetString(0),
                                contact = reader.IsDBNull(1) ? null : reader.GetString(1),
                                name = reader.IsDBNull(2) ? null : reader.GetString(2),
                                birthday = reader.IsDBNull(3) ? null : reader.GetString(3),
                                email = reader.IsDBNull(4) ? null : reader.GetString(4)
                            });
                        }
                    }
                }

                return CustomerModels;
            }
        }

        public bool DeleteCustomer(string customer_id)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionstring].ToString()))
            {
                con.Open();
                string query = @"
                        UPDATE customer
                        set customer_status = 0
                        WHERE customer_id = @customer_id";

                using (var cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@customer_id", customer_id);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
    }
}
