using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listex
{
    class Student
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public string Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        public override string ToString()
        {
            return Id + "-" + StudentName + "-" + Gender + "-" + Birthday + "-" + Address;
        }
    }
}
