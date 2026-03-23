using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Assignmemt_inventory;
using IOOP;

namespace Main_Page
{
    internal class BookingControl
    {
        private Form parentForm;

        private GroupBox[] boxs;
        private Label[] dates;
        private Label[] times;
        private Label[] paxs;
        private Label[] halls;
        private Label[] labels;
        private Label[] requests;
        private Label[] status;

        private List<ReservationModel> reservations;
        private HallModel hall;

        public BookingControl(Form parentForm, GroupBox[] boxs, Label[] dates, Label[] times, Label[] paxs, Label[] halls, Label[] labels, Label[] requests, Label[] status)
        {
            this.parentForm = parentForm;
            this.boxs = boxs;
            this.dates = dates;
            this.times = times;
            this.paxs = paxs;
            this.halls = halls;
            this.labels = labels;
            this.requests = requests;
            this.status = status;
        }

        public void LoadData()
        {
            ReservationService _reservationService = new ReservationService("VegeMeat");
            reservations = _reservationService.GetReservationByCustomerID(SessionManager.Instance.CustomerId);


            BindIDToLabel();
            BindDateToLabel();
            BindTimeToLabel();
            BindPaxToLabel();
            BindHallToLabel();
            BindRequestToLabel();
            BindStatusToLabel();
        }

        public void CheckData()
        {
            if (reservations.Count == 0)
            {
                MessageBox.Show("No Reservation Record!");
            }
        }

        private void BindIDToLabel()
        {
            for (int i = 0; i < boxs.Length; i++)
            {
                if (i < reservations.Count)
                {
                    boxs[i].Text = reservations[i].reservation_id;
                    boxs[i].Visible = true;
                }
                else
                {
                    boxs[i].Visible = false;
                }
            }

        }

        private void BindDateToLabel()
        {
            for (int i = 0; i < dates.Length; i++)
            {
                if (i < reservations.Count)
                {
                    dates[i].Text = reservations[i].date;
                    dates[i].Visible = true;
                }
                else
                {
                    dates[i].Visible = false;
                }
            }
        }

        private void BindTimeToLabel()
        {
            for (int i = 0; i < times.Length; i++)
            {
                if (i < reservations.Count)
                {
                    times[i].Text = $"Time : {reservations[i].time}";
                    times[i].Visible = true;
                }
                else
                {
                    times[i].Visible = false;
                }
            }
        }

        private void BindPaxToLabel()
        {
            for (int i = 0; i < paxs.Length; i++)
            {
                if (i < reservations.Count)
                {
                    paxs[i].Text = $"Pax  : {reservations[i].pax}";
                    paxs[i].Visible = true;
                }
                else
                {
                    paxs[i].Visible = false;
                }
            }
        }

        private void BindHallToLabel()
        {
            for (int i = 0; i < halls.Length; i++)
            {
                if (i < reservations.Count)
                {
                    HallService _hallService = new HallService("VegeMeat");
                    hall = _hallService.GetHallNameByID(reservations[i].hall_id);

                    halls[i].Text = $"Hall : {hall.name}";
                    halls[i].Visible = true;
                }
                else
                {
                    halls[i].Visible = false;
                }
            }
        }

        private void BindRequestToLabel()
        {
            for (int i = 0; i < requests.Length; i++)
            {
                if (i < reservations.Count)
                {
                    if (reservations[i].request != "")
                    {
                        requests[i].Text = reservations[i].request;
                        requests[i].Visible = true;
                        labels[i].Visible = true;
                    }
                    else
                    {
                        requests[i].Text = "-";
                    }
                }
                else
                {
                    requests[i].Visible = false;
                    labels[i].Visible = false;
                }
            }
        }

        private void BindStatusToLabel() 
        {
            for (int i = 0; i < status.Length; i++)
            {
                if (i < reservations.Count)
                {
                    status[i].Text = $"Status : {reservations[i].status}";
                    status[i].Visible = true;
                }
                else
                {
                    status[i].Visible = false;
                }
            }
        }
    }
}
