using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerApp
{
    class Program
    {
        static Thread thread;
        static TcpListener listener;
        static void Main(string[] args)
        {
            thread = new Thread(new ThreadStart(RunListener));
            thread.Start();
            Console.ReadLine();
        }

        private static void RunListener()
        {
            listener = new TcpListener(IPAddress.Any, 9999);
            listener.Start();
            Console.WriteLine("Sever running");
            do
            {
                TcpClient c = listener.AcceptTcpClient();
                using (var stream=c.GetStream())
                {
                    StreamReader sr = new StreamReader(stream);
                    string data = sr.ReadToEnd();
                    string ip = (c.Client.RemoteEndPoint as IPEndPoint).Address.ToString();
                    Console.WriteLine(ip+": "+data);

                }
                c.Close();
            } while (true);
        }
    }
}
