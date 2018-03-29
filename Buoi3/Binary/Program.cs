using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO
using System.Runtime.Serialization.Formatters.Binary;

namespace Binary
{
    class Program
    {
        static Setting settings;
        static void LoadSetting()
        {
            if (!File.Exists("set.bin")) return;
            Stream stream = File.OpenRead("set.bin");
            BinaryFormatter formatter = new BinaryFormatter();
            settings=(Setting) formatter.Deserialize(stream);
            stream.Close();
        }
        static void SaveSetting()
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
