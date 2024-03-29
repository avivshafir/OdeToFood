﻿using System.Security.AccessControl;

namespace OdeToFood.Models
{
    public class RestaurantListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int CountOfReviews { get; set; }
    }
}