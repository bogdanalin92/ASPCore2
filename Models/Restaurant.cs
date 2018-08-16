using System;
using System.ComponentModel.DataAnnotations;

namespace ASPCore2.Models {
    public class Restaurant{
        public int Id {get;set;}

        [Display(Name="Restaurant Name")]
        public string Name {get;set;}
        public CuisineType Cuisine {get; set;}
    }
}