using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TreeDirDemo
{
    class Program
    {
        static void GetDir(string dir, string t)
        {
            Console.WriteLine(t + "D: " + dir.Split('\\').Last());

            string tab = "---" + t;
            foreach(string d in Directory.GetDirectories(dir))
            {
                //Console.WriteLine("D: " + d);
                GetDir(d, tab);
            }

            foreach(string f in Directory.GetFiles(dir))
            {
                Console.WriteLine(tab + "F: " + f.Split('\\').Last());
            }
        }
        static void Main(string[] args)
        {
            GetDir(@"D:\Works\SEM 3 - 1. CSharp Basic", "");

            Console.ReadLine();
        }
    }
}
