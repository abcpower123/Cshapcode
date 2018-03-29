using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace CayThuMuc
{
    class Program
    {
        static void GetDir(string dir,string tab)
        {
            Console.WriteLine(tab+dir.Split('\\').Last()+":");
            tab = tab + "\t";
            foreach (string d in Directory.GetDirectories(dir))
            {
               // Console.WriteLine(d+"\\");
                GetDir(d,tab);
            }
            foreach (string s in Directory.GetFiles(dir))
            {
                Console.WriteLine(tab+s.Split('\\').Last());
            }
            //nghien cuu them create, delete, exist
        }

        static void Main(string[] args)
        {
            GetDir(@"D:\soft","");
            Console.ReadLine();
        }
    }
}
