using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace EncryptFileDemo
{
    class Program
    {
        static void Encrypt(string file)
        {
            byte[] data = File.ReadAllBytes(file);
            data = data.Reverse().ToArray();
            Stream stream = File.Create(file);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, data);
            stream.Close();
        }
        static void Decrypt(string file)
        {
            Stream stream = File.OpenRead(file);
            BinaryFormatter formatter = new BinaryFormatter();
            byte[] data= (byte[]) formatter.Deserialize(stream); stream.Close();
            data=data.Reverse().ToArray();

            File.WriteAllBytes(file, data);
        }
        static void Main(string[] args)
        {
            
        }
    }
}
