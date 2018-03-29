using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesEx
{
    public class MathEx
    {
        public void add(int a, int b)
        {
            Console.WriteLine(a + b);
        }
        public void sub(int a, int b)
        {
            Console.WriteLine(a - b); ;
        }
    }
    class Program
    {
        delegate void Calc(int a, int b);
        static void Main(string[] args)
        {
            MathEx math = new MathEx();
            Calc calc = new Calc(math.add);

            calc += math.sub;

            calc(10, 15);
            Console.WriteLine("----------");

            calc -= math.sub;
            calc(2, 3);
            Console.ReadLine();
        }
    }
}
