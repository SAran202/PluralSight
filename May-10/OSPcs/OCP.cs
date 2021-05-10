using System;
using System.Collections.Generic;
using System.Text;

namespace OSPcs
{
    public class OCP
    {
        public virtual int ReturnNumber(int No)
        {
            return No - 2;
        }
    }
    public class FinalOCP : OCP
    {
        public override int ReturnNumber(int No)
        {
            return base.ReturnNumber(No) - 5;
        }
    }
    public class ProposedOCP : OCP
    {
        public override int ReturnNumber(int No)
        {
            return base.ReturnNumber(No) - 4;
        }
    }
    public class RecurringOCP : OCP
    {
        public override int ReturnNumber(int No)
        {
            return base.ReturnNumber(No) - 3;
        }
    }
}
