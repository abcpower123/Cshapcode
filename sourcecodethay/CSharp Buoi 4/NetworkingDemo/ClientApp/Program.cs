using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string host = "localhost";
            int port = 9999;

            Console.Write("Host: ");
            host = Console.ReadLine();

            while (true)
            {
                Console.Write("Send to {0}: ", host);
                string data = Console.ReadLine();

                TcpClient c = new TcpClient(host, port);
                using (var stream = c.GetStream())
                {
                    StreamWriter sw = new StreamWriter(stream);
                    sw.Write(data);
                    sw.Flush();
                }
                c.Close();
            }
        }
    }
}
