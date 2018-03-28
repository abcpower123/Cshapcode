using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListExample
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            while (true)
            {
                Student s = new Student();
                Console.Write("Id = ");
                try
                {
                    s.Id = int.Parse(Console.ReadLine());
                    if (s.Id == 0) break;
                    
                    Console.Write("Student Name = ");
                    s.StudentName = Console.ReadLine();

                    Console.Write("Gender = ");
                    s.Gender = Console.ReadLine();

                    Console.Write("Birthday = ");
                    s.Birthday = DateTime.Parse(Console.ReadLine());

                    Console.Write("Address = ");
                    s.Address = Console.ReadLine();

                    students.Add(s);
                }
                catch { }
            }
            /*
            Student student = students.Where(x => x.Id == 2).FirstOrDefault();
            if(student != null)
            {
                //student.StudentName = "Kha Kha";
                students.Remove(student);
            }
            */
            var scount = students.GroupBy(x => x.Birthday < new DateTime(2000, 9, 1));
            Console.WriteLine("List students: ");
            foreach(Student st in students)
            {
                Console.WriteLine(st.ToString());
            }

            Console.ReadLine();
        }
    }
}
