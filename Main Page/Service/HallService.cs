using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignmemt_inventory
{
    internal class HallService
    {
        private readonly HallRepository _hallRepository;

        public HallService(string connectionString)
        {
            _hallRepository = new HallRepository(connectionString);
        }

        public HallModel GetHallByID(string hall_id)
        {
            return _hallRepository.GetHallByID(hall_id);
        }

        public HallModel GetHallNameByID(string hall_id)
        {
            return _hallRepository.GetHallNameByID(hall_id);
        }

        public List<HallModel> GetAllHall()
        {
            return _hallRepository.GetAllHall();
        }

        public List<HallModel> GetActiveHall()
        {
            return _hallRepository.GetActiveHall();
        }

        public bool AddHall(string hall_id, string name, string description, int maxcapacity, string type, string restaurant_id)
        {
            var hallModels = new HallModel { hall_id = hall_id, name = name, description = description, maxcapacity = maxcapacity, type = type, restaurant_id = restaurant_id };
            return _hallRepository.AddHall(hallModels);
        }

        public bool UpdateHall(string hall_id, string name, string description, int maxcapacity, string type, string restaurant_id)
        {
            var hallModels = new HallModel { name = name, description = description, maxcapacity = maxcapacity, type = type, restaurant_id = restaurant_id };
            return _hallRepository.UpdateHall(hallModels, hall_id);
        }

        public bool HallStatus(string hall_id, int is_active)
        {
            return _hallRepository.HallStatus(hall_id, is_active);
        }

    }
}
