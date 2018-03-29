using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ThiThu_Hao
{
    class Program
    {
        static Student st;

        static void LoadStudent()
        {
           // if (!File.Exists("Student.xml")) return;
            try
            {
                Stream stream = File.OpenRead("Student.xml");
                XmlSerializer serializer = new XmlSerializer(typeof(Student));
                st = (Student)serializer.Deserialize(stream);
                stream.Close();
            }
            catch (Exception)
            {
                st = new Student();
            }

        }
        static void ShowStudent()
        {
            Console.WriteLine("--------------------------------");
            Console.WriteLine("Fullname: "+st.FullName);
            Console.WriteLine("Batch: "+st.Batch);
            Console.WriteLine("Phone: " + st.Phone);
            Console.WriteLine("Email: " + st.Email);
            Console.WriteLine("Address: " + st.Address);
            Console.WriteLine("--------------------------------");
        }
        static void SaveStudent()
        {
            Stream stream = File.Create("Student.xml");
            XmlSerializer serializer = new XmlSerializer(typeof(Student));
            serializer.Serialize(stream, st);
            stream.Close();
        }
        static void ChangeStudent()
        {
            Console.WriteLine("Please input student:");
            Console.Write("Fullname: ");
            st.FullName = Console.ReadLine();

            Console.Write("Batch: ");
            st.Batch = Console.ReadLine();

            Console.Write("Phone: ");
            st.Phone = Console.ReadLine();

            Console.Write("Email: ");
            st.Email = Console.ReadLine();

            Console.Write("Address: ");
            st.Address = Console.ReadLine();
        }
        static void Main(string[] args)
        {
            LoadStudent();
            ShowStudent();
            ChangeStudent();
            SaveStudent();
            Console.ReadLine();
        }
    }
}
