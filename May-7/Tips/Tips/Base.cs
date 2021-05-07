using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tips
{
    class Base
    {
        static void Main(string[] args)
        {
            var list = new List<Item>();
            list.Add(new Item<int>());
            list.Add(new Item<double>());
        }
    }
    public class Item<T>:Item
    {
        //Helps to add different types
    }
    public class Item
    {
        //Base
    }
}
