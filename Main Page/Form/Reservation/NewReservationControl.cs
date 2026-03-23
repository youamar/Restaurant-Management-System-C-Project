using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Assignmemt_inventory;
using IOOP;

namespace Main_Page
{
    internal class NewReservationControl
    {
        private  ReservationService _reservationsService;
        private  HallService _hallService;
        private List<HallModel> halls;

        private ComboBox halldata;
        
        private string date;
        private string time;
        private string pax;
        private string request;
        private string selectedHall;

        public NewReservationControl(ComboBox hall)
        {
            this.halldata = hall;
        }

        public NewReservationControl(DateTimePicker date, ComboBox time, ComboBox pax, ComboBox hall, TextBox request)
        {
            this.date = date.Value.ToString("dd/MM/yyyy");
            this.time = time.SelectedItem?.ToString() ?? "";
            this.pax = pax.SelectedItem?.ToString() ?? "";
            this.selectedHall = hall.SelectedItem?.ToString() ?? "";
            this.request = request.Text;
        }



        public void LoadHallData()
        {
            _hallService = new HallService("VegeMeat");
            halls = _hallService.GetActiveHall();

            halldata.Items.Clear();
            foreach (var data in halls)
            {
                halldata.Items.Add(data.name);
            }
        }

        public void AddReservation()
        {
            _hallService = new HallService("VegeMeat");
            halls = _hallService.GetAllHall();

            var hall = halls.FirstOrDefault(h => h.name == selectedHall);
            if (hall == null)
            {
                MessageBox.Show("Selected hall not found.");
                return;
            }

            string hall_id = hall.hall_id;

            Random random = new Random();
            string reservation_id = $"R{DateTime.Now:MMddHHmm}{random.Next(10, 99)}";

            _reservationsService = new ReservationService("VegeMeat");
            _reservationsService.AddReservation(reservation_id, SessionManager.Instance.CustomerId, date, time, pax, request, hall_id, "PENDING");
        }

        public void ClearType(ComboBox time, ComboBox pax, ComboBox hall, TextBox request)
        {
            time.SelectedIndex = -1;
            pax.SelectedIndex = -1;
            hall.SelectedIndex = -1;
            request.Text = "";
        }

    }
}
