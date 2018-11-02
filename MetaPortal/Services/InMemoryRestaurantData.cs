using MetaPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetaPortal.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        public InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>
            {
                    new Restaurant { Id = 001, Name = "Stock Announcement - Week 40"},
                    new Restaurant { Id = 002, Name = "Stock Announcement - Week 41"},
                    new Restaurant { Id = 003, Name = "Stock Announcement - Week 42"}
            };
        }
        
        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants.OrderBy(r => r.Name);
        }

        public Restaurant Get(int id)
        {
            return _restaurants.FirstOrDefault(r => r.Id == id);
        }

        public Restaurant Add(Restaurant restaurant)
        {
            restaurant.Id = _restaurants.Max(r => r.Id) + 1;
            _restaurants.Add(restaurant);
            return restaurant;
        }

        List<Restaurant> _restaurants;
    }
}
