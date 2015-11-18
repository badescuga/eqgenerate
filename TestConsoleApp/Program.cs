using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            //Eq eq1 = new Eq(new EqNumber(28), new EqNumber(85), OperationType.Minus);
            //Eq eq2 = new Eq(eq1, new EqNumber(43), OperationType.Minus);
            //Eq eq3 = new Eq(eq2, new EqNumber(88), OperationType.Plus);

            //Eq eq123 = new Eq(new Eq(new EqNumber(27), new EqNumber(97), OperationType.Plus), eq3, OperationType.Minus);
            //Console.WriteLine("---- " + eq123.TString()+" value:" +eq123.Calculate());


            int level;
            EqElement eq = null;
            int valConv = 0;
            var arg = args.Length > 0 ? args[0] : "3"; // for testing from visual studio
            
            if (Int32.TryParse(arg, out level))
            {
                Console.WriteLine("level selected:" + level);
                
                //generate the equation 
                eq = EqGenerator.Generate(level, level);
                Console.WriteLine("simplified: " + eq.TString());
                Console.WriteLine("tree: " + eq.ToTree());
                Console.WriteLine("(because i cheat, the response is " + eq.Calculate() + ")");
                Console.WriteLine("enter value:");

                //read until i get the correct answer
                bool done = false;
                var equationValue = eq.Calculate();
                do
                {
                    string str = Console.ReadLine();
                    if (Int32.TryParse(str, out valConv))
                    {
                        if (valConv == equationValue)
                        {
                            done = true;
                            Console.WriteLine("CORRECT!");
                        }
                        else
                        { // missed number
                            Console.WriteLine("Try again!");
                        }
                    }
                    else
                    { // wrote a string that wasn't a number
                        Console.WriteLine("Not a number. Try again!");
                    }
                } while (done == false);
            }
            else
            { //argument is invalid 
                Console.WriteLine("== arg not int");
            }
            Console.ReadLine();
        }
    }
}
