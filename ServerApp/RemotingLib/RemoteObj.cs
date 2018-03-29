using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemotingLib
{
    public class RemoteObj :MarshalByRefObject
    {
        public bool checkLogin(string username,string password)
        {
            return (username.Equals("abc") && password.Equals("123"));
            
        }
        public string GetHello(string name)
        {
            return "Hello, " + name;
        }
    }
}
