using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MetaPortal.Data;
using MetaPortal.Models;

namespace MetaPortal.Services
{
    public class SqlRestaurantData : IRestaurantData
    {
        private MetaPortalDbContext _context;

        public SqlRestaurantData(MetaPortalDbContext context)
        {
            _context = context;
        }
        public Restaurant Add(Restaurant restaurant)
        {
            _context.Restaurants.Add(restaurant);
            _context.SaveChanges();
            return restaurant;
        }

        public Restaurant Get(int id)
        {
            return _context.Restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _context.Restaurants.OrderBy(r => r.Name);
        }
    }
}