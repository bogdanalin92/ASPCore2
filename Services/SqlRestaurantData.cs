using System.Collections.Generic;
using System.Linq;
using ASPCore2.Data;
using ASPCore2.Models;

namespace ASPCore2.Services
{
    public class SqlRestaurantData : IRestaurantData
    {
        private ASPCore2DbContext _context;

        public SqlRestaurantData(ASPCore2DbContext context)
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

        public Restaurant Update(Restaurant restaurant)
        {
            throw new System.NotImplementedException();
        }
    }
}