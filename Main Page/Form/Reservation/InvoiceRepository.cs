using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace Class
{
    internal class InvoiceRepository
    {
        private readonly string _connectionstring;
        public InvoiceRepository(string connectionstring)
        {
            _connectionstring = connectionstring;
        }
        public InvoiceModel GetInvoiceByID(string invoice_id)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionstring].ToString()))
            {
                con.Open();
                string query = @"SELECT * FROM invoice where invoice_id = @invoice_id";

                using (var cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@invoice_id", invoice_id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new InvoiceModel
                            {
                                invoice_id = reader.GetString(0),
                                order_id = reader.GetString(1),
                                amount = reader.GetDecimal(2),  
                                reservation_id = reader.GetString(3),
                                invoice_status = reader.GetString(4)
                            };
                        }
                    }
                }
            }
            return null;
        }

        public bool AddInvoice(InvoiceModel invoice,string invoice_id)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionstring].ToString()))
            {
                con.Open();
                string query = @"INSERT INTO invoice(invoice_id, order_id, amount, reservation_id,invoice_status)
                VALUES (@invoice_id,@order_id,@amount,@reservation_id,@status)";
                using (var cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@invoice_id", invoice_id);
                    cmd.Parameters.AddWithValue("@order_id",invoice.order_id );
                    cmd.Parameters.AddWithValue("@amount", invoice.amount);
                    cmd.Parameters.AddWithValue("@reservation_id", invoice.reservation_id);
                    cmd.Parameters.AddWithValue("@status", invoice.invoice_status);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
        public bool UpdateInvoice(string invoice_id, decimal amount, string invoice_status)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionstring].ToString()))
            {
                con.Open();
                string query = @"UPDATE invoice 
                         SET amount = @amount, invoice_status = @invoice_status 
                         WHERE invoice_id = @invoice_id";

                using (var cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@invoice_id", invoice_id);
                    cmd.Parameters.AddWithValue("@amount", amount);
                    cmd.Parameters.AddWithValue("@invoice_status", invoice_status);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
        public decimal GetRevenueByDate(DateTime date)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionstring].ToString()))
            {
                con.Open();
                string query = @"SELECT SUM(i.amount) 
                         FROM invoice i
                         JOIN reservation r ON i.reservation_id = r.reservation_id
                         WHERE CAST(r.dining_date AS DATE) = @date";

                using (var cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@date", date.Date); // 只取日期部分
                    var result = cmd.ExecuteScalar();
                    return result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                }
            }
        }
    }
}
