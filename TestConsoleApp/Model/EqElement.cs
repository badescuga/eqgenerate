using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleApp
{
    //public enum ElementType { None = 0, Simple, Composed } // simple is just a number, composed is an equation with nested components
    public enum OperationType { None = 0, Plus, Minus, Multiply, Divide }

    abstract class EqElement
    {
        //public ElementType Type = ElementType.None;
        public OperationType Operation = OperationType.None;
        public abstract float Calculate();
        public abstract string TString(bool withMinus=false);
        public abstract string ToTree();
    }
}
