using System;

namespace OSPcs
{
    class Program
    {
        static void Main(string[] args)
        {
            OCP Fo = new FinalOCP();
            OCP Po = new ProposedOCP();
            OCP Ro = new RecurringOCP();

            int FinalOCP = Fo.ReturnNumber(10);
            int ProposedOCP = Po.ReturnNumber(10);
            int RecurringOCP = Ro.ReturnNumber(10);

            Console.ReadKey();
        }
    }
}
