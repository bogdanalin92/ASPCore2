using System;
using ASPCore2.Models;
using System.ComponentModel.DataAnnotations;

namespace ASPCore2.ViewModels {
    public class RestaurantEditModel {

        [Required,MaxLength(50)]
        public string Name {get;set;}
        public CuisineType Cuisine {get;set;}
    }
}