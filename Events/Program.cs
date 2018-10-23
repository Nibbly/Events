using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new Adder();
            //a.OnMultipleOfFiveReached += new Adder.dgEventRaiser(a_MultipleOfFiveReached);
            a.OnMultipleOfFiveReached += a_MultipleOfFiveReached;

            int iAnswer = a.Add(4, 3);
            Console.WriteLine("iAnswer = {0}", iAnswer);
            iAnswer = a.Add(4, 6);
            Console.WriteLine("iAnswer = {0}", iAnswer);
            Console.ReadKey();
        }

        static void a_MultipleOfFiveReached(object sender, MultipleOfFiveEventArgs e)
        {
            Console.WriteLine("Multiple of five reached!");
            Console.WriteLine(sender.GetType());
            Console.WriteLine(e.Total + " is a multiple of five");
        }
    }

    public class Adder
    {
        public event EventHandler<MultipleOfFiveEventArgs> OnMultipleOfFiveReached;

        public int Add(int x, int y)
        {
            int iSum = x + y;
            if ((iSum % 5 == 0) && (OnMultipleOfFiveReached != null))
            {
                OnMultipleOfFiveReached(this, new MultipleOfFiveEventArgs(iSum));
            }
            return iSum;
        }
    }

    public class MultipleOfFiveEventArgs : EventArgs
    {
        public int Total { get; set; }

        public MultipleOfFiveEventArgs(int iTotal)
        {
            Total = iTotal;
        }
    }
}
