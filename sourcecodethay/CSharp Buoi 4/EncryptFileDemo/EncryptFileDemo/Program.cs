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
        static void Encrypt(string file, string pass)
        {
            FileData obj = new FileData();
            obj.Password = pass;
            obj.data = File.ReadAllBytes(file);
            obj.data = obj.data.Reverse().ToArray();//dao nguoc
            //them nhieu kieu

            Stream stream = File.Create(file);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, obj);
            stream.Close();
        }

        static void Decrypt(string file, string pass)
        {
            Stream stream = File.OpenRead(file);
            BinaryFormatter formatter = new BinaryFormatter();
            FileData obj = (FileData)formatter.Deserialize(stream);
            stream.Close();
            if (obj.Password.Equals(pass))
            {
                obj.data = obj.data.Reverse().ToArray();//dao nguoc
                File.WriteAllBytes(file, obj.data);
                Console.WriteLine("Xong");
            }
            else
            {
                Console.WriteLine("Bay goy!");
            }
        }

        static void Main(string[] args)
        {
            //Encrypt("D:\\Lyrics.docx", "xxx");
            Decrypt("D:\\Lyrics.docx", "xxx");

            Console.ReadLine();
        }
    }
}
