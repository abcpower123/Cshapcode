using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            
            DataFromLyric_Karaoke_Com data=new DataFromLyric_Karaoke_Com("Ánh Sao Băng");

            var s = data.Search();
            Console.WriteLine(s[0].href);
            Console.ReadLine();
        }
    }
}
