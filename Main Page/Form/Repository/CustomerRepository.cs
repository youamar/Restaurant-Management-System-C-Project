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
        public CustomerModel GetCustomerByID(string customer_id)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionstring].ToString()))
            {
                con.Open();
                string query = @"SELECT * FROM customer where customer_id = @customer_id";

                using (var cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@customer_id", customer_id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new CustomerModel
                            {
                                customer_id = reader.GetString(0),
                                contact = reader.GetString(1),
                                name = reader.GetString(2),
                                birthday = reader.GetString(3),
                            };
                        }
                    }
                }
                return null;
            }

        }
        public bool AddCustomer(CustomerModel customer,string customer_id)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionstring].ToString()))
            {
                con.Open();
                string query = @"INSERT INTO customer(customer_id, customer_contact, customer_name, customer_birthday
                VALUES (@customer_id,@contact,@name,@birthday)";
                using(var cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@customer_id", customer_id);
                    cmd.Parameters.AddWithValue("@contact", customer.contact);
                    cmd.Parameters.AddWithValue("@name", customer.name);
                    cmd.Parameters.AddWithValue("@birthday", customer.birthday);
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
                string query = @"UPDATE customer
                set customer_contact = @contact,
                WHERE customer_id = @customer_id";
                using (var cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@customer_id", customer_id);
                    cmd.Parameters.AddWithValue("@contact", customer.contact);
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
                SELECT cutomer_id, customer_contact
                FROM customer";

                using (var cmd = new SqlCommand(query,con))
                using(var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CustomerModels.Add(new CustomerModel
                        {
                            customer_id = reader.GetString(0),
                            contact = reader.GetString(1),
                        });
                    }
                }
                return CustomerModels;
            }
        }
        public bool DeleteCustomer(CustomerModel customer,string customer_id)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionstring].ToString()))
            {
                con.Open();
                string query = @"DELETE FROM customer WHERE customer_id=@customer_id";

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
