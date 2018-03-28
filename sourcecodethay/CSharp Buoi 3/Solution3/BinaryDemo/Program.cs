using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace BinaryDemo
{
    class Program
    {
        static Settings settings;

        static void LoadSettings()
        {
            if (!File.Exists("set.bin")) return;

            Stream stream = File.OpenRead("set.bin");
            BinaryFormatter formatter = new BinaryFormatter();
            settings = (Settings)formatter.Deserialize(stream);
            stream.Close();
        }
        static void SaveSettings()
        {
            Stream stream = File.Create("set.bin");
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, settings);
            stream.Close();
        }

        static void Main(string[] args)
        {

        }
    }
}
