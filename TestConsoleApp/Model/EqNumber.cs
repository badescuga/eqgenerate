using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleApp
{
    class EqNumber : EqElement // number included in R
    {
        public float Val
        {
            get; set;
        }

        public EqNumber(float val) {
            Val = val;
            //Type = ElementType.Simple;
            Operation = OperationType.None;
        }

        public override float Calculate()
        {
            return Val;
        }

        public override string TString(bool withMinus=false)
        {
           return Val.ToString();
        }

        public override string ToTree() {
            return Val.ToString();
        }
    }
}
