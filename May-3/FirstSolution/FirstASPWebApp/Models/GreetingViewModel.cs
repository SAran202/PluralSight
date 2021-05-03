using FirstASPWebData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstASPWebApp.Models
{
    public class GreetingViewModel
    {
        public IEnumerable<Restaurant> Restaurants { get; set; }
        public string Msg { get; set; }
        public string Sts { get; set; }
        public string Name { get; set; }
    }
}