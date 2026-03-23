using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOOP
{
    internal class ReservationRepository
    {

        private readonly string _connectionString;

        public ReservationRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<ReservationModel> GetReservationByCustomerID(string customer_id)
        {
            List<ReservationModel> ReservationModels = new List<ReservationModel>();

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionString].ToString()))
            {
                conn.Open();
                string query = @"
                    SELECT *
                    FROM reservation
                    WHERE reservation.customer_id = @customer_id
                    ORDER BY last_update DESC";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@customer_id", customer_id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ReservationModels.Add(new ReservationModel
                            {
                                reservation_id = reader.IsDBNull(0) ? null : reader.GetString(0),
                                customer_id = reader.IsDBNull(1) ? null : reader.GetString(1),
                                date = reader.IsDBNull(2) ? null : reader.GetString(2),
                                time = reader.IsDBNull(3) ? null : reader.GetString(3),
                                pax = reader.IsDBNull(4) ? null : reader.GetString(4),
                                request = reader.IsDBNull(5) ? null : reader.GetString(5),
                                status = reader.IsDBNull(6) ? null : reader.GetString(6),
                                hall_id = reader.IsDBNull(7) ? null : reader.GetString(7)
                            });
                        }
                    }
                }
            }
            return ReservationModels;
        }

        public List<ReservationModel> GetAllReservation()
        {
            List <ReservationModel> ReservationModels = new List <ReservationModel> ();

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionString].ToString()))
            {
                conn.Open();
                string query = @"
                    SELECT *
                    FROM reservation";

                using (var cmd = new SqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ReservationModels.Add(new ReservationModel
                            {
                                reservation_id = reader.IsDBNull(0) ? null : reader.GetString(0),
                                customer_id = reader.IsDBNull(1) ? null : reader.GetString(1),
                                date = reader.IsDBNull(2) ? null : reader.GetString(2),
                                time = reader.IsDBNull(3) ? null : reader.GetString(3),
                                pax = reader.IsDBNull(4) ? null : reader.GetString(4),
                                request = reader.IsDBNull(5) ? null : reader.GetString(5),
                                status = reader.IsDBNull(6) ? null : reader.GetString(6),
                                hall_id = reader.IsDBNull(7) ? null : reader.GetString(7)
                            });
                        }
                    }
                }
            }
            return ReservationModels;
        }

        public int GetReservationCount(string hall_id, string status)
        {
            List<ReservationModel> ReservationModels = new List<ReservationModel>();

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionString].ToString()))
            {
                conn.Open();
                string query = @"SELECT COUNT(reservation_id) FROM reservation WHERE hall_id = @hall_id";

                if (status == "COMPLETED")
                {
                    query += " AND reservation_status = @status";
                }
                else if (status == null)
                {
                    query += " AND reservation_status != @status";
                }

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@hall_id", hall_id);

                    if (status == "COMPLETED")
                    {
                        cmd.Parameters.AddWithValue("@status", status);
                    }
                    else if (status == null)
                    {
                        cmd.Parameters.AddWithValue("@status", "COMPLETED");
                    }

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.GetInt32(0); // 读取 COUNT 结果
                        }
                    }
                }
            }

            return 0;
        }


        public bool AddReservation(ReservationModel reservation)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionString].ToString()))
            {
                conn.Open();
                string query = @"
                    INSERT INTO reservation (reservation_id, customer_id, dining_date, dining_time, pax, special_request, reservation_status, hall_id)
                    VALUES 
                    (@reservation_id, @customer_id, @date, @time, @pax, @request, @reservation_status, @hall_id)";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@reservation_id", reservation.reservation_id);
                    cmd.Parameters.AddWithValue("@customer_id", reservation.customer_id);
                    cmd.Parameters.AddWithValue("@date", reservation.date);
                    cmd.Parameters.AddWithValue("@time", reservation.time);
                    cmd.Parameters.AddWithValue("@pax", reservation.pax);
                    cmd.Parameters.AddWithValue("@request", reservation.request);
                    cmd.Parameters.AddWithValue("@reservation_status", reservation.status);
                    cmd.Parameters.AddWithValue("@hall_id", reservation.hall_id);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public bool UpdateReservation(ReservationModel reservation, string reservation_id)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionString].ToString()))
            {
                conn.Open();
                string query = @"
                    UPDATE reservation
                    SET reservation_status = @status,
                        hall_id = @hall_id,
                        role_id = @role_id
                    WHERE reservation_id = @reservation_id";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@reservation_id", reservation_id);
                    cmd.Parameters.AddWithValue("@status", reservation.status);
                    cmd.Parameters.AddWithValue("@hall_id", reservation.hall_id);
                    cmd.Parameters.AddWithValue("@role_id", reservation.role_id);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public bool CancelReservation(ReservationModel reservation, string reservation_id)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionString].ToString()))
            {
                conn.Open();
                string query = @"
                    UPDATE reservation
                    SET reservation_status = @status,
                    WHERE reservation_id = @reservation_id";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@reservation_id", reservation.reservation_id);
                    cmd.Parameters.AddWithValue("@status", reservation.status);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }

        }
    }
}
