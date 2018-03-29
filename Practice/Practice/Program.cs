using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Practice
{
    class Program
    {
        static List<Person> data;
        static string fileName = "Person.xml";
        static void LoadPersons()
        {
            try
            {
                Stream stream = File.OpenRead(fileName);
                XmlSerializer xml = new XmlSerializer(typeof( List < Person >));
                data= (List<Person>)xml.Deserialize(stream);
                if (stream != null) stream.Close();
               
            }
            catch (Exception)
            {

                data = new List<Person>();
            }
            

        }
        static void SavePersons()
        {
            try
            {
                Stream stream = File.Create(fileName);
                XmlSerializer xml = new XmlSerializer(typeof(List<Person>));
                xml.Serialize(stream, data);
                if (stream != null) stream.Close();

            }
            catch (Exception)
            {

                Console.WriteLine("ERR");
            }
        }
        static void Display()
        {
            foreach (var p in data)
            {
                Console.WriteLine("ID: "+p.Id);
                Console.WriteLine("Name: " + p.FullName);
                Console.WriteLine("Date of birth: " + p.DateOfBirth.ToString("dd/MM/yyyy"));
                
                Console.WriteLine("Phone: " + p.Phone);
                Console.WriteLine("Email: " + p.Email);
                Console.WriteLine("Address: " + p.Address);
                Console.WriteLine("------------------------------");
            }
        }
        static void Input()
        {
            Console.WriteLine("Input: ");
            while (true)
            {
                Person p = new Person();

                Console.Write("ID: ");
                p.Id = int.Parse(Console.ReadLine());
                var p2 = data.Where(x => x.Id == p.Id).FirstOrDefault();
                if (p2 != null) continue;
                if (p.Id<=0)
                {
                    break;
                }
                Console.Write("Name: ");
                p.FullName = Console.ReadLine();
                Console.Write("Day of birth: ");
                p.DateOfBirth =DateTime.Parse( Console.ReadLine());
                Console.Write("Phone: ");
                p.Phone = Console.ReadLine();
                Console.Write("Email: ");
                p.Email = Console.ReadLine();
                Console.Write("Address: ");
                p.Address = Console.ReadLine();
                data.Add(p);
                SavePersons();

            }
        }
        static void Main(string[] args)
        {
            LoadPersons();
            Display();
            Input();
            Console.ReadLine();
        }
    }
}
