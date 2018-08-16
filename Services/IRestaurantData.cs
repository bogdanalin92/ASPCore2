using System.Collections.Generic;
using ASPCore2.Models;

namespace ASPCore2.Services{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
        Restaurant Get(int id);
        Restaurant Add(Restaurant restaurant);
    }
}