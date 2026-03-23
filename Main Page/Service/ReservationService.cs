using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOOP
{
    internal class ReservationService
    {
        private readonly ReservationRepository _reservationRepository;

        public ReservationService(string connectionString)
        {
            _reservationRepository = new ReservationRepository(connectionString);
        }

        public List<ReservationModel> GetReservationByCustomerID(string customer_id)
        {
            return _reservationRepository.GetReservationByCustomerID(customer_id);
        }

        public List<ReservationModel> GetAllReservation()
        {
            return _reservationRepository.GetAllReservation();
        }

        public int GetReservationCount(string hall_id, string status)
        {
            return _reservationRepository.GetReservationCount(hall_id, status);
        }

        public bool AddReservation(string reservation_id, string customer_id, string date, string time, string pax, string request, string hall_id, string status)
        {
            var reservationModels = new ReservationModel { reservation_id = reservation_id, customer_id = customer_id, date = date, time = time, pax = pax, request = request, hall_id = hall_id, status = status };
            return _reservationRepository.AddReservation(reservationModels);
        }

        public bool UpdateReservation(string reservation_id, string status, string hall_id, string role_id)
        {
            var reservationModels = new ReservationModel { status = status, hall_id = hall_id, role_id = role_id };
            return _reservationRepository.UpdateReservation(reservationModels, reservation_id);
        }

        public bool CancelReservation(string reservation_id, string status)
        {
            var reservationModels = new ReservationModel { reservation_id= reservation_id, status = status };
            return _reservationRepository.CancelReservation(reservationModels, reservation_id);
        }
    }
}
