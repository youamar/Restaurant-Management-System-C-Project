using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Assignmemt_inventory;
using Class;
using IOOP;

namespace Main_Page
{
    internal class HallReportControl
    {
        private readonly ReservationService _reservationService;
        private readonly HallService _hallService;
        private readonly RoleService _roleService;

        private List<HallModel> halls;

        private ListBox listbox;

        public HallReportControl(ListBox listbox )
        {
            _reservationService = new ReservationService("VegeMeat");
            _hallService = new HallService("VegeMeat");
            _roleService = new RoleService("VegeMeat");

            this.listbox = listbox;
        }

        public string RoleName()
        {
            RoleModel role = _roleService.GetRoleByID(SessionManager.Instance.RoleId);
            return $"{role.role} {role.role_name.Split(' ')[0]}";
        }

        public void loadHall()
        {
            listbox.Items.Clear();
            halls = _hallService.GetAllHall();

            foreach ( HallModel hall in halls )
            {
                listbox.Items.Add( hall.name );
            }
        }

        public void loadHallData(Label[] labels)
        {
            int reserved = _reservationService.GetReservationCount(halls[listbox.SelectedIndex].hall_id, null);
            int used = _reservationService.GetReservationCount(halls[listbox.SelectedIndex].hall_id, "COMPLETED");

            labels[0].Text = $"Hall ID : {halls[listbox.SelectedIndex].hall_id}";
            labels[1].Text = $"Hall Name : {halls[listbox.SelectedIndex].name}";
            labels[2].Text = $"Approximate Pax : {halls[listbox.SelectedIndex].maxcapacity}";
            labels[3].Text = $"Party Type : {halls[listbox.SelectedIndex].type}";
            labels[4].Text = $"{halls[listbox.SelectedIndex].description}";

            if (halls[listbox.SelectedIndex].is_active == 1)
            {
                labels[5].Text = $"Availability : On Sales Hall";
            }
            else if (halls[listbox.SelectedIndex].is_active == 0)
            {
                labels[5].Text = $"Availability : Not On Sales Hall";
            }
            else
            {
                labels[5].Text = $"Availability : Unreachable Status";
            }

            labels[6].Text = $"Reservation Number :{reserved}";
            labels[7].Text = $"Expriencing Number :{used}";
        }
    }
}