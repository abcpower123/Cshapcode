using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SecurityDemo
{
    class Program
    { 
        static string EncryptPass(string pass)
        {
            SHA256 sHA = SHA256Managed.Create();
          
            byte[] data = Encoding.UTF8.GetBytes(pass);
            byte[] result=sHA.ComputeHash(data);
            string enpass = BitConverter.ToString(result);
            return enpass.Replace("-", "").ToLower();

        }
        static void Register(string pass)
        {
            File.WriteAllText("abc.user",EncryptPass(pass));
            Console.WriteLine("Register successfully!");
        }
        static bool Login(string pass)
        {
            string enpass = EncryptPass(pass);
            string dbpass = File.ReadAllText("abc.user");
            return dbpass.Equals(enpass);
        }
        static void Main(string[] args)
        {
            Console.Write("Enter new passworld: ");
            Register(Console.ReadLine());

            Console.Write("Login pass: ");
            if (Login(Console.ReadLine()))
            {
                Console.WriteLine("Login ok");
            }
            else
            {
                Console.WriteLine("Invalid");
            }
            Console.ReadLine();
        }
    }
}
