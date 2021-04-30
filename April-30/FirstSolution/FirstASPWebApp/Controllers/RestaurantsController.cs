using FirstASPWebData.Models;
using FirstASPWebData.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstASPWebApp.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly IRestaurantData db;
        public RestaurantsController(IRestaurantData db)
        {
            this.db = db;
        }
        [HttpGet]
        // GET: Restaurants
        public ActionResult Index()
        {
            var model = db.GetAll();
            return View(model);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = db.Get(id);
            if(model==null)
            {
                return View("Not Found");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Restaurant restaurant)
        {
            if(String.IsNullOrEmpty(restaurant.Name))
            {
                ModelState.AddModelError(nameof(restaurant.Name), "The name is required");
            }
            if (ModelState.IsValid)
            {
                db.Add(restaurant);
                return RedirectToAction("Details",new { id = restaurant.ID });
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var model = db.Get(id);
            if(model==null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Restaurant restaurant)
        {
            if(ModelState.IsValid)
            {
                db.Update(restaurant);
                return RedirectToAction("Details", new { id = restaurant.ID });
            }
            return View(restaurant);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var model = db.Get(id);
            if(model==null)
            {
                return View("Not Found");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id,FormCollection form)
        {
            db.Delete(id);
            return RedirectToAction("Index");
        }
    }
}