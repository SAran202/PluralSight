using FirstASPWebApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstASPWebApp.Controllers
{
    public class GreetingController : Controller
    {
        // GET: Greeting
        public ActionResult Index(string name)
        {
            var model = new GreetingViewModel();
            model.Name = name ?? "no Name";
            model.Msg = ConfigurationManager.AppSettings["msg"];
            model.Sts = ConfigurationManager.AppSettings["sts"];
            return View(model);
        }
    }
}