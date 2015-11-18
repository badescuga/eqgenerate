using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleApp
{
    class Eq : EqElement
    {
        public EqElement LeftVal {
            get;
            set;
        }
        public EqElement RightVal
        {
            get;
            set;
        }


        public Eq(EqElement leftVal, EqElement rightVal, OperationType operation) {
            LeftVal = leftVal;
            RightVal = rightVal;
            Operation = operation;
        }

        public override float Calculate() {
            float val = 0;
            switch (Operation) {
                case OperationType.Plus:
                    val = LeftVal.Calculate() + RightVal.Calculate();
                    break;
                case OperationType.Minus:
                    val = LeftVal.Calculate() - RightVal.Calculate();
                    break;
                case OperationType.Multiply:
                    val = LeftVal.Calculate() * RightVal.Calculate();
                    break;
                case OperationType.Divide:
                    val = LeftVal.Calculate() / RightVal.Calculate();
                    break;
            }
            return val;
        }

        public override string TString(bool withMinus=false)
        {
            var op = Operation;
            string val = "";
            if (op == OperationType.Plus && withMinus) {
                op = OperationType.Minus;
            } else if (op == OperationType.Minus && withMinus) {
                op = OperationType.Plus;
            }
            switch (op)
            {
                case OperationType.Plus:
                    val = LeftVal.TString(withMinus) + " + " + RightVal.TString(withMinus);
                    break;
                case OperationType.Minus:
                    val = LeftVal.TString(withMinus) + " - " + RightVal.TString(true);
                    break;
                case OperationType.Multiply:

                    if (LeftVal.Operation == OperationType.Divide || LeftVal.Operation == OperationType.Multiply || LeftVal.Operation == OperationType.None) {
                        val += LeftVal.TString();
                    } else {
                        val += "(" + LeftVal.TString()+ ")";
                    }
                    val += " * ";

                    if (RightVal.Operation == OperationType.Divide || RightVal.Operation == OperationType.Multiply || RightVal.Operation == OperationType.None) {
                        val += RightVal.TString();
                    } else {
                        val += "(" + RightVal.TString() + ")";
                    }

                    break;
                case OperationType.Divide:
                    if (LeftVal.Operation == OperationType.Divide || LeftVal.Operation == OperationType.Multiply || LeftVal.Operation == OperationType.None) {
                        val += LeftVal.TString();
                    }  else {
                        val += "(" + LeftVal.TString() + ")";
                    }
                    val += " / ";

                    if (RightVal.Operation == OperationType.Divide || RightVal.Operation == OperationType.Multiply || RightVal.Operation == OperationType.None) {
                        val += RightVal.TString();
                    }  else {
                        val += "(" + RightVal.TString() + ")";
                    }

                    break;
            }
            return val;
        }


        public override string ToTree() {
            var op = Operation;
            string val = "";
            switch (op) {
                case OperationType.Plus:
                    val = LeftVal.ToTree() + " + " + RightVal.ToTree();
                    break;
                case OperationType.Minus:
                    val = LeftVal.ToTree() + " - " + RightVal.ToTree();
                    break;
                case OperationType.Multiply:
                    val = LeftVal.ToTree() + " * " + RightVal.ToTree();
                    break;
                case OperationType.Divide:
                    val = LeftVal.ToTree() + " / " + RightVal.ToTree();
                    break;
            }

            val = "(" + val + ")";
            return val;
        }


    }
}
