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

        public ReservationModel GetReservationByCustomerID(string customer_id)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionString].ToString()))
            {
                conn.Open();
                string query = @"
                    SELECT *
                    FROM reservation
                    WHERE reservation.customer_id = @customer_id";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@customer_id", customer_id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new ReservationModel
                            {
                                reservation_id = reader.GetString(0),
                                customer_id = reader.GetString(1),
                                date = reader.GetString(2),
                                time = reader.GetString(3),
                                pax = reader.GetInt32(4),
                                request = reader.GetString(5),
                                status = reader.GetString(6),
                                hall_id = reader.GetString(7)
                            };
                        }
                    }
                }
            }
            return null;
        }

        public List<ReservationModel> GetAllReservation()
        {
            List <ReservationModel> ReservationModels = new List <ReservationModel> ();

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionString].ToString()))
            {
                conn.Open();
                string query = @"
                    SELECT reservation_id, reservation_status
                    FROM reservation";

                using (var cmd = new SqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ReservationModels.Add(new ReservationModel
                        {
                            reservation_id = reader.GetString(0),
                            status = reader.GetString(6)
                        });
                    }
                }
            }
            return ReservationModels;
        }

        public bool AddReservation(ReservationModel reservation, string customer_id)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings[_connectionString].ToString()))
            {
                conn.Open();
                string query = @"
                    INSERT INTO reservation (reservation_id, customer_id, dining_date, dining_time, pax, special_request)
                    VALUES 
                    (@reservation_id, @customer_id, @date, @time, @pax, @request)";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@reservation_id", reservation.reservation_id);
                    cmd.Parameters.AddWithValue("@customer_id", customer_id);
                    cmd.Parameters.AddWithValue("@date", reservation.date);
                    cmd.Parameters.AddWithValue("@time", reservation.time);
                    cmd.Parameters.AddWithValue("@pax", reservation.pax);
                    cmd.Parameters.AddWithValue("@request", reservation.request);
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
                        role_id = @role_id,
                    WHERE reservation_id = @reservation_id";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@reservation_id", reservation.reservation_id);
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
