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

        public List<InvoiceModel> GetInvoiceByID(string customer_id)
        {
            List<InvoiceModel> _invoiceModel = new List<InvoiceModel>();

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionstring].ToString()))
            {
                con.Open();
                string query = @"
                        SELECT invoice.invoice_id, invoice.order_id, invoice.amount, invoice.invoice_status, invoice.last_update
                        FROM invoice
                        LEFT JOIN orders ON orders.order_id = invoice.order_id
                        LEFT JOIN customer ON customer.customer_id = orders.customer_id
                        where customer.customer_id = @customer_id
                        ORDER BY invoice.last_update DESC";

                using (var cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@customer_id", customer_id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            _invoiceModel.Add(new InvoiceModel
                            {
                                invoice_id = reader.GetString(0),
                                order_id = reader.GetString(1),
                                amount = reader.GetDecimal(2),
                                invoice_status = reader.GetString(3),
                                date = reader.GetDateTime(4).ToString("yyyy/MM/dd")
                            });
                        }
                    }
                }
            }
            return _invoiceModel;
        }

        public bool AddInvoice(InvoiceModel invoice)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionstring].ToString()))
            {
                con.Open();
                string query = @"
                        INSERT INTO invoice (invoice_id, order_id, amount, invoice_status)
                        VALUES (@invoice_id, @order_id, @amount, @status)";
                using (var cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@invoice_id", invoice.invoice_id);
                    cmd.Parameters.AddWithValue("@order_id", invoice.order_id );
                    cmd.Parameters.AddWithValue("@amount", invoice.amount);
                    cmd.Parameters.AddWithValue("@status", invoice.invoice_status);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
        public bool UpdateInvoice(string order_id, string invoice_status)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionstring].ToString()))
            {
                con.Open();
                string query = @"UPDATE invoice 
                         SET invoice_status = @invoice_status 
                         WHERE order_id = @order_id";

                using (var cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@order_id", order_id);
                    cmd.Parameters.AddWithValue("@invoice_status", invoice_status);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
        public decimal GetRevenueByMonth(DateTime date)
        {
            int year = date.Year;
            int month = date.Month;

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionstring].ToString()))
            {
                con.Open();
                string query = @"
                        SELECT SUM(amount) 
                        FROM invoice
                        WHERE MONTH(last_update) = @month AND YEAR(last_update) = @year";

                using (var cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@month", month);
                    cmd.Parameters.AddWithValue("@year", year);

                    var result = cmd.ExecuteScalar();
                    return result != DBNull.Value ? Convert.ToDecimal(result) : 0;
                }
            }
        }
    }
}
