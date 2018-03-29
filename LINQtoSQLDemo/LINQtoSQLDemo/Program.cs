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
            using (var db=new dbDataContext())
            {
                //insert


                //Student s = new Student()
                //{
                //    StudentName = "Nguyen Vien",
                //    Birthday = new DateTime(1990, 10, 1),
                //    Email = "cuvien@viencu.com",
                //    Phone = "0909090909",
                //    Address = "Đà Nẵng"
                //};
                //db.Students.InsertOnSubmit(s);
                //db.SubmitChanges();
                //Console.WriteLine(s.Id);

                //endinsert

                //update
                Student ss = db.Students.Where(x => x.Id == 2).SingleOrDefault();
                //if (ss!=null)
                //{
                //    ss.StudentName = "Hào";
                //    db.SubmitChanges();
                //}

                //delete
                if (ss!=null)
                {
                    db.Students.DeleteOnSubmit(ss);
                    db.SubmitChanges();
                }
                foreach (var s in db.Students)
                {
                    Console.WriteLine(s.Id+" - " + s.StudentName);
                }
                Console.ReadLine();
            }
        }
    }
}
