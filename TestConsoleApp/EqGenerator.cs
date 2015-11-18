using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleApp
{
    class EqGenerator
    {
        private static readonly Random mRandom = new Random();
        public static EqElement Generate(int level, int originalLevel) {

            if (level == 1) {
                var nr = new EqNumber(GenNumber(1, 101));
              //  Console.WriteLine("current level 1. val:"+nr.TString());
                return nr;
            } else {
                //generate operation number
                int randOperation = GenNumber(1, 4); // exclude divide

                //generate level for each side of the eq
                int randLevelLeft = GenNumber(1, level);
                int randLevelRight = level - randLevelLeft;

                //get actual eq generated
             //   Console.WriteLine("==== splitting in: " + randLevelLeft + " and " + randLevelRight);
                OperationType opType = (OperationType)randOperation;
                EqElement eqLeft = Generate(randLevelLeft, originalLevel);
                EqElement eqRight = Generate(randLevelRight, originalLevel);

                //special condition for "/", articifial
                float valEqLeft = eqLeft.Calculate();
                float valEqRight = eqRight.Calculate();
                if (valEqLeft / valEqRight == (int)(valEqLeft / valEqRight)) {
                 //   Console.WriteLine("!!!! --- " + valEqLeft + " " + valEqRight);
                    opType = OperationType.Divide;
                }
                var eqFinal = new Eq(eqLeft, eqRight, opType);
             //   Console.WriteLine("current level: " + level + " left:" + eqLeft.TString() + " right:" + eqRight.TString()+" operation:"+opType.ToString() + " result:" + eqFinal.Calculate());


                if (originalLevel == level) { //test for >= 0
                    if (eqFinal.Calculate() > 0) {
                        return eqFinal;
                    }  else  {
                  //      Console.WriteLine("eq is <= 0; RESETTING");
                        return Generate(originalLevel, originalLevel);
                    }
                }
                else {
                    return eqFinal;
                }
            }
        }

        static int GenNumber(int start, int end) {
            return mRandom.Next(start, end); // interval: [start,end-1] i.e. doesn't take the last end value
        }


    }
}
