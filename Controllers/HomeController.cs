using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPCore2.Models;
using ASPCore2.Services;
using ASPCore2.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ASPCore2 {
    public class HomeController : Controller{
        private IRestaurantData _restaurantData;
        private IGreeter _greeter;

        public HomeController(IRestaurantData restaurantData,
                                IGreeter greeter)
        {
            _restaurantData = restaurantData;
            _greeter = greeter;
        }
        public IActionResult Index(){
            var model = new HomeIndexViewModel();
            model.Restaurants = _restaurantData.GetAll();
            model.CurrentMessage = _greeter.GetMessageOfTheDay();
            return View(model);
        }

        public IActionResult Details(int id){
            var model = _restaurantData.Get(id);
            if(model == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Create(){
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RestaurantEditModel model){
            if(ModelState.IsValid){
                var newRestaurant = new Models.Restaurant();
                newRestaurant.Name = model.Name;
                newRestaurant.Cuisine = model.Cuisine;
                newRestaurant = _restaurantData.Add(newRestaurant);
                return RedirectToAction(nameof(Details), new {id = newRestaurant.Id } );
            }
            else{
                return View();
            }
        }
    }
}