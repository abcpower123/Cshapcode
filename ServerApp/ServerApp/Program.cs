using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using RemotingLib;
namespace ServerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpChannel channel = new HttpChannel(5555);
            ChannelServices.RegisterChannel(channel);

            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemoteObj),
                "TienHai", WellKnownObjectMode.SingleCall);
            Console.WriteLine("Server is running...");
            Console.ReadLine();
        }
    }
}
