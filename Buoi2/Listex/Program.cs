using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listex
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            students.Add(new Student()
            {
                Id = 2,
                StudentName = "ss",
                Gender = "nam"
            });
        }
    }
}
