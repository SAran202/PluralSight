using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tips
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new NxtItem<int>();
            var b = new NxtItem<int>();
            var c = new NxtItem<string>();

            Console.WriteLine(NxtItem.InstanceCount);
            //Console.WriteLine(NxtItem<string>.InstanceCount);
        }
    }
    public class NxtItem<T> : NxtItem
    {

    }
    public class NxtItem
    {
        public NxtItem()
        {
            InstanceCount += 1;
        }
        public static int InstanceCount;
    }
}
