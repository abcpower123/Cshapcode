using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingExample
{
    class Program
    {
        static Thread threadTick;
        static int count = 0;
        static void Main(string[] args)
        {
            threadTick = new Thread(new ThreadStart(runTick));
            threadTick.Start();
          
            Console.WriteLine("Starting...");
            //lam chi do
           
            Console.ReadLine();
            threadTick.Abort();
        }

        private static void runTick()
        {
            while (true)
            {
                Console.WriteLine("count= "+count++);
                Thread.Sleep(1000);
            }
        }
    }
}
