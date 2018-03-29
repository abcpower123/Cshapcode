using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace TestFileDemo
{
    class Program
    {
        static List<Student> list=new List<Student>();
        static void Nhap()
        {
            while (true)
            {
                Student s = new Student();
                Console.Write("ID: ");
                s.Id = int.Parse(Console.ReadLine());
                if (s.Id == 0) return;
                Console.Write("Student name: ");
                s.StudentName = Console.ReadLine();
                Console.Write("Birtday: ");
                s.Birthday = DateTime.Parse(Console.ReadLine());
                list.Add(s);
            }
        }
        static void Xuat()
        {
            foreach (var s in list)
            {
                Console.WriteLine(s.Id+" - "+s.StudentName+" - "+s.Birthday);
            }
        }
        static void SaveText()
        {
            string data = "";
            foreach (var s in list)
            {
                data += s.Id + ";" + s.StudentName + ";" + s.Birthday.ToString("dd/MM/yyyy")+"\n";
            }
            File.WriteAllText("Student.txt", data);
        }
        static void LoadText()
        {

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
            if (!File.Exists("a.xml"))  return;
            Stream stream = File.OpenRead("a.xml");
            XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));
            list= (List<Student>) serializer.Deserialize(stream);
            stream.Close();
        }
        static void SaveJson()
        {
            string data = JsonConvert.SerializeObject(list);
            File.WriteAllText("Student.json", data);
        }
        static void LoadJson()
        {
            if (!File.Exists("Student.json"))
            {
                return;
            }
            string data = File.ReadAllText("Student.json");
            list = JsonConvert.DeserializeObject<List<Student>>(data);
        }
        static void Main(string[] args)
        {
            LoadJson();
            if(list.Count==0)
            Nhap();

            Xuat();
            SaveJson();
            Console.ReadLine();
        }
    }
}
