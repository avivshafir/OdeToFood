using System.Collections.Generic;
using OdeToFood.Models;

namespace OdeToFood.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<OdeToFood.Models.OdeToFoodDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(OdeToFood.Models.OdeToFoodDb context)
        {
            context.Restaurants.AddOrUpdate(r => r.Name,
                new Restaurant {Name = "Sabatino's", City = "Baltimore", Country = "USA"},
                new Restaurant {Name = "Great Lake", City = "Chicago", Country = "USA"},
                new Restaurant
                {
                    Name = "Smake",
                    City = "Gothenburg",
                    Country = "Sweden",
                    Reviews = new List<RestaurantReview>
                    {
                        new RestaurantReview {Rating = 9, Body = "Great Food!"}
                    }
                });

            for (int i = 0; i < 1000; i++)
            {
                context.Restaurants.AddOrUpdate(r => r.Name,
                    new Restaurant { Name = i.ToString(), City = "NoWhere", Country = "USA" });
            }
        }
    }
}
