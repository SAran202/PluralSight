using System;

namespace LSPcs
{
    class Program
    {
        static void Main(string[] args)
        {
            Car c = new BMW();
            Console.WriteLine(c.Type());
            c = new Benz();
            Console.WriteLine(c.Type());
        }
    }
    public abstract class Car
    {
        public abstract string Type();
    }
    public class BMW : Car
    {
        public override string Type()
        {
            return "Race";
        }
    }
    public class Benz : Car
    {
        public override string Type()
        {
            return "Race";
        }
    }
}
