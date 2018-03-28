using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQtoSQLDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new StudentsDBDataContext())
            {
                //Insert
                /*Student s = new Student();
                s.StudentName = "Nguyen Vien";
                s.Birthday = new DateTime(1990, 10, 1);
                s.Email = "cuvien@viencu.com";
                s.Phone = "0909090909";
                s.Address = "Da Nang";
                db.Students.InsertOnSubmit(s);
                db.SubmitChanges();
                Console.WriteLine(s.Id);
                */

                //Update
                /*Student st = db.Students.Where(x => x.Id == 3).SingleOrDefault();
                if(st != null)
                {
                    st.StudentName = "Le Map";
                    db.SubmitChanges();
                }
                */

                //Delete
                Student st = db.Students.Where(x => x.Id == 3).SingleOrDefault();
                if (st != null)
                {
                    db.Students.DeleteOnSubmit(st);
                    db.SubmitChanges();
                }

                var list = db.Students
                    //.Where(x => x.StudentName.Contains("Nguyen"))
                    .OrderBy(x => x.Birthday).ToList();

                foreach (Student s in list)
                {
                    Console.WriteLine(s.Id + "\t" + s.StudentName);
                }

                Console.WriteLine("Count: " + db.Students.Count());
                Console.ReadLine();
            }
        }
    }
}
