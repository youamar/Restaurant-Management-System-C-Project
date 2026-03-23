using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Assignmemt_inventory;
using Class;
using IOOP;

namespace Main_Page
{
    internal class ManageReservationControl
    {
        private ReservationService _reservationService;
        private CustomerService _customerService;
        private HallService _hallService;
        private MessageService _messageService;
        private RoleService _roleService;

        private ListBox lstall;
        private ListBox lstdetail;
        private ComboBox cmbhall;

        private List<ReservationModel> reservations;
        private List<HallModel> halls;

        public ManageReservationControl(ListBox lstall, ListBox lstdetail, ComboBox cmbhall)
        {
            _reservationService = new ReservationService("VegeMeat");
            _customerService = new CustomerService("VegeMeat");
            _hallService = new HallService("VegeMeat");
            _messageService = new MessageService("VegeMeat");
            _roleService = new RoleService("VegeMeat");

            this.lstall = lstall;
            this.lstdetail = lstdetail;
            this.cmbhall = cmbhall;
        }

        public string LoadRoleTItle()
        {
            RoleModel role = _roleService.GetRoleByID(SessionManager.Instance.RoleId);
            return $"{role.role.Split(' ')[1]} {role.role_name.Split(' ')[0]}";
        }

        public void LoadAllReservations()
        {
            reservations = _reservationService.GetAllReservation();

            lstall.Items.Clear();

            for (int i = 0; i < reservations.Count; i++)
            {
                lstall.Items.Add($"{reservations[i].reservation_id}-{reservations[i].status}");
            }
        }

        public void LoadAllHall()
        {
            halls = _hallService.GetActiveHall();

            cmbhall.Items.Clear();

            foreach (HallModel hall in halls)
            {
                cmbhall.Items.Add(hall.name);
            }
        }

        public void ShowReservationDetails()
        {
            lstdetail.Items.Clear();

            if (lstall.SelectedIndex == -1)
            {
                MessageBox.Show("No Reservation Selected!");
                return;
            }

            ReservationModel reservation = reservations[lstall.SelectedIndex];

            CustomerModel customer = _customerService.GetCustomerByCustomerId(reservation.customer_id);
            HallModel hall = _hallService.GetHallByID(reservation.hall_id);

            lstdetail.Items.Add($"Customer Contact : {customer.contact}");
            lstdetail.Items.Add($"Prefered Hall : {hall.name}");
            lstdetail.Items.Add($"Dining Date : {reservation.date}");
            lstdetail.Items.Add($"Dining Time : {reservation.time}");
            lstdetail.Items.Add($"Pax : {reservation.pax}");
            if (reservation.request != "")
            {
                lstdetail.Items.Add($"Request : {reservation.request}");
            }
        }

        public void AssignHall()
        {
            if (lstall.SelectedIndex == -1)
            {
                MessageBox.Show("No Reservation Selected!");
                return;
            }

            if (cmbhall.SelectedIndex == -1)
            {
                MessageBox.Show("No Hall Selected!");
                return;
            }

            string reservation_id = reservations[lstall.SelectedIndex].reservation_id;
            string hall_id = halls[cmbhall.SelectedIndex].hall_id;

            if (_reservationService.UpdateReservation(reservation_id, "PENDING", hall_id, SessionManager.Instance.RoleId))
            {
                MessageBox.Show("Hall assigned successfully!");
                RefreshData();
            }
            else
            {
                MessageBox.Show("Failed assigned hall!");
            }
        }

        public void ReplyMessage(String message)
        {
            if (lstall.SelectedIndex == -1)
            {
                MessageBox.Show("No Reservation Selected!");
                return;
            }

            if (message == "")
            {
                MessageBox.Show("No Message Written");
                return;
            }

            List<MessageModel> messages = _messageService.GetAllMessages();
            string message_id = $"M{messages.Count + 1}";

            string reservation_id = reservations[lstall.SelectedIndex].reservation_id;

            if (_messageService.AddMessage(message_id, message, reservation_id))
            {
                MessageBox.Show("Message Replied!");
                RefreshData();
            }
            else
            {
                MessageBox.Show("Failed To Reply Message!");
            }
        }

        public void UpdateStatus(string status)
        {
            if (lstall.SelectedIndex == -1)
            {
                MessageBox.Show("No Reservation Selected!");
                return;
            }

            string reservation_id = reservations[lstall.SelectedIndex].reservation_id;
            string hall_id = reservations[lstall.SelectedIndex].hall_id;

            if (_reservationService.UpdateReservation(reservation_id, status, hall_id, SessionManager.Instance.RoleId))
            {
                MessageBox.Show("Update successfully!");
                RefreshData();
            }
            else
            {
                MessageBox.Show("Update Failed!");
            }
        }

        public void ViewCustomerProfile()
        {
            if (lstall.SelectedIndex == -1)
            {
                MessageBox.Show("No Reservation Selected!");
                return;
            }

            string customer_id = reservations[lstall.SelectedIndex].customer_id;

            CustomerProfile profile = new CustomerProfile(customer_id);
            profile.Show();
        }

        private void RefreshData()
        {
            LoadAllReservations();
        }
    }
}
