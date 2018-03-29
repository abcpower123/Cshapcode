using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraticeFiles
{
    [Serializable]
    public class Student
    {
      
        public string StudentName { get; set; }
        public string Batch { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime Birtday { get; set; }
        public int Id { get; set; }
    }
}
