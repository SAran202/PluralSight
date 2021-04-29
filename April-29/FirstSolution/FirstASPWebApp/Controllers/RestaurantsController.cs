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
        public RestaurantsController(IRestaurantData db)
        {
            this.Db = db;
        }

        public IRestaurantData Db { get; }

        // GET: Restaurants
        public ActionResult Index()
        {
            var model = Db.GetAll();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = Db.Get(id);
            return View(model);
        }
    }
}