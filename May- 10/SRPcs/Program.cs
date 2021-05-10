using System;

namespace SRPcs
{
    class Program
    {
        static void Main(string[] args)
        {
            ClassA.Check(1);
            ClassB.Check(2);
        }
        public static class ClassA
        {
            public static void Check(int No)
            {
                if (No == 1)
                {
                    throw new Exception("No is 1");
                }
            }
        }
        public static class ClassB
        {
            public static void Check(int No)
            {
                if (No == 2)
                {
                    throw new Exception("No is 2");
                }
            }
        }
    }
}
