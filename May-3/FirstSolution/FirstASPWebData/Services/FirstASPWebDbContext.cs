using FirstASPWebData.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstASPWebData.Services
{
    public class FirstASPWebDbContext:DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
