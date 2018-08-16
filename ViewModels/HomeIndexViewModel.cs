using System.Collections.Generic;
using ASPCore2.Models;

namespace ASPCore2.ViewModels{
    public class HomeIndexViewModel {
        public IEnumerable<Restaurant> Restaurants {get; set;}
        public string CurrentMessage {get; set;}
    }
}