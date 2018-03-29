using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PraticeFiles
{
    class Program
    {
        static Student data;
        //xml
        static void LoadStudent()
        {
            Stream stream = null;
            try
            {
                stream = File.OpenRead("student.xml");
                XmlSerializer serializer = new XmlSerializer(typeof(Student));
                data = (Student)serializer.Deserialize(stream);
                stream.Close();
            }
            catch (Exception ex)
            {
                data = new Student();
            }
        }
        static void SaveStudent()
        {
            XmlSerializer xml = new XmlSerializer(typeof(Student));
            xml.Serialize(File.Create("student.xml"),data);
        }
        static void Display()
        {
            Console.WriteLine("ID: " + data.Id);
            Console.WriteLine("Name: "+data.StudentName);
            Console.WriteLine("Birthday: " + data.Birtday.ToString("dd/MM/yyyy"));
            Console.WriteLine("Batch: " + data.Batch);
            Console.WriteLine("Email: " + data.Email);
            Console.WriteLine("Address: " + data.Address);
        }
        static void Input()
        {
            Console.Write("ID: ");
            data.Id = int.Parse(Console.ReadLine());
            Console.Write("Name: ");
            data.StudentName = Console.ReadLine();
            Console.Write("Birthday: ");
            data.Birtday =DateTime.Parse(Console.ReadLine());
            Console.Write("Batch: ");
            data.Batch =Console.ReadLine();
            Console.Write("Email: ");
            data.Email = Console.ReadLine();
            Console.Write("Address: ");
            data.Address = Console.ReadLine();

        }

        //binanry
        static void LoadStudentBin()
        {
            try
            {
                BinaryFormatter binary = new BinaryFormatter();
                data = (Student)binary.Deserialize(File.OpenRead("student.bin")); //stream auto close when method finished
            }
            catch
            {
                data = new Student();
            }
        }
        static void SaveStudentBin()
        {
            try
            {
                BinaryFormatter binary = new BinaryFormatter();
                binary.Serialize(File.Create("student.bin"),data);//stream auto close when method finished
            }
            catch
            {
                Console.WriteLine("ERR");
            }
        }

        //json
        static void LoadStudentJSon()
        {
            if (!File.Exists("Student.json"))
            {
                data = new Student();
            }
            else
            data = JsonConvert.DeserializeObject<Student>(File.ReadAllText("Student.json"));
        }
        static void SaveStudentJSon()
        {
            string json = JsonConvert.SerializeObject(data);
            File.WriteAllText("Student.json", json);

        }
        static void Main(string[] args)
        {
            //xml
            //LoadStudent();
            //Display();
            //Input();
            //SaveStudent();
            //Console.ReadLine();

            //LoadStudentBin();
            //Display();
            //Input();
            //SaveStudentBin();

            LoadStudentJSon();
            Display();
            Input();
            SaveStudentJSon();
            Console.ReadLine();
        }
    }
}
