using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using RemotingLib;
namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClientChannel channel = new HttpClientChannel();
            ChannelServices.RegisterChannel(channel);
            RemoteObj obj = (RemoteObj) Activator.GetObject(typeof(RemoteObj), "http://localhost:5555/tienhai");
            if (obj.checkLogin("abc", "123"))
            {
                Console.WriteLine("OK");
            }
            else {
                Console.WriteLine("Bay r");
            }
            Console.ReadLine();
        }
    }
}
