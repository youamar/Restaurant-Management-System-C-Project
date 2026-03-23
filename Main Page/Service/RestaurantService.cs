using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Assignmemt_inventory
{
    internal class RestaurantService
    {
        private readonly RestaurantRepository _restaurantRepository;

        public RestaurantService(string connectionString)
        {
            _restaurantRepository = new RestaurantRepository(connectionString);
        }

        public RestaurantModel GetRestaurantData()
        {
            return _restaurantRepository.GetRestaurantData();
        }
    }
}
