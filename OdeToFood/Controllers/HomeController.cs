﻿using System.Linq;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using OdeToFood.Models;
using PagedList;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        private OdeToFoodDb _db = new OdeToFoodDb();

        public ActionResult AutoComplete(string term)
        {
            var model = 
                _db.Restaurants
                    .Where(r => r.Name.StartsWith(term))
                    .Take(10)
                    .Select(r => new
                    {
                        label = r.Name
                    });

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index(string searchTerm = null, int page = 1)
        {
            //LINQ Comprehension Method Syntax
            //var model = from r in _db.Restaurants
            //    orderby r.Reviews.Average(review => review.Rating) descending
            //    select new RestaurantListViewModel
            //    {
            //        Id = r.Id,
            //        Name = r.Name,
            //        City = r.City,
            //        Country = r.Country,
            //        CountOfReviews = r.Reviews.Count()
            //    };

            //LINQ Extenstion Method Syntax
            var model = _db.Restaurants
                .OrderByDescending(r => r.Reviews.Average(review => review.Rating))
                .Where(r => searchTerm == null || r.Name.StartsWith(searchTerm))
                .Select(r => new RestaurantListViewModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    City = r.City,
                    Country = r.Country,
                    CountOfReviews = r.Reviews.Count()
                }).ToPagedList(page, 10);


            if (Request.IsAjaxRequest())
            {
                return PartialView("_Restaurants", model);
            }

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (_db != null)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
