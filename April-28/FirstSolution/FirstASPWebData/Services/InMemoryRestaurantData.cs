using FirstASPWebData.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstASPWebData.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant{ID=1,Name="Product 1",Cuisine=CuisineType.French},
                new Restaurant{ID=2,Name="Product 2",Cuisine=CuisineType.Indian},
                new Restaurant{ID=3,Name="Product 3",Cuisine=CuisineType.Italian}
            };
        }
        public IEnumerable<Restaurant> GetAll()
        {
            return restaurants.OrderBy(r => r.Name);
        }
    }
}
