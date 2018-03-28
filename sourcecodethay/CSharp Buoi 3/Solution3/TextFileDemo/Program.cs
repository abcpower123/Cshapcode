using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TextFileDemo
{
    class Program
    {
        static List<Student> list = new List<Student>();

        static void InputData()
        {
            Console.WriteLine("Input student info:");

            while (true)
            {
                Student s = new Student();
                Console.Write("Id = ");
                s.Id = int.Parse(Console.ReadLine());
                if (s.Id == 0) break;

                Console.Write("Student Name = ");
                s.StudentName = Console.ReadLine();

                Console.Write("Birthday = ");
                s.Birthday = DateTime.Parse(Console.ReadLine());

                list.Add(s);
                //SaveData();
                //SaveXml();
                SaveJson();
            }
        }
        static void DisplayData()
        {
            Console.WriteLine("List of students:");
            foreach (Student s in list)
            {
                Console.WriteLine(s.Id + "\t" + s.StudentName + "\t" + s.Birthday.ToString("dd/MM/yyyy"));
            }
        }

        static void SaveData()
        {
            string data = "";

            foreach (Student s in list)
            {
                data += s.Id + ";"
                    + s.StudentName + ";"
                    + s.Birthday.ToString()
                    + Environment.NewLine;
            }
            File.WriteAllText("students.txt", data);
        }

        static void LoadData()
        {
            foreach (string line in File.ReadAllLines("students.txt"))
            {
                if (!String.IsNullOrEmpty(line))
                {
                    string[] ds = line.Split(';');
                    Student s = new Student();
                    s.Id = int.Parse(ds[0]);
                    s.StudentName = ds[1];
                    s.Birthday = DateTime.Parse(ds[2]);

                    list.Add(s);
                }
            }
        }

        static void SaveXml()
        {
            Stream stream = File.Create("a.xml");
            XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));
            serializer.Serialize(stream, list);
            stream.Close();
        }
        static void LoadXml()
        {
            if (!File.Exists("a.xml")) return;

            Stream stream = File.OpenRead("a.xml");
            XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));
            list = (List<Student>)serializer.Deserialize(stream);
            stream.Close();
        }

        static void SaveJson()
        {
            string data = JsonConvert.SerializeObject(list);
            File.WriteAllText("s.json", data);
        }

        static void LoadJson()
        {
            if (!File.Exists("s.json")) return;

            string data = File.ReadAllText("s.json");
            list = JsonConvert
                .DeserializeObject<List<Student>>(data);

        }

        static void Main(string[] args)
        {
            //LoadXml();
            LoadJson();

            InputData();

            DisplayData();

            Console.ReadLine();

        }
    }
}
