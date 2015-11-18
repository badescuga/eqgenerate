using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleApp
{
    public enum OperationType { None = 0, Plus, Minus, Multiply, Divide }

    abstract class EqElement
    {
        public OperationType Operation = OperationType.None;
        public abstract float Calculate();
        public abstract string TString(bool withMinus=false); // simplified view of the tree
        public abstract string ToTree(); // actual tree with ( ) to highlight the actual structure
    }
}
