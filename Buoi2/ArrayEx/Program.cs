using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayEx
{
    class Program
    {
        static void Main(string[] args)
        {
            int []arr = { 5, 8, 7, 13, 20, 4, 5,6,4,30,1 };
            /*
            for (int i = 1; i < arr.Length; i++)
            {
                for (int j = arr.Length - 1; j >= i; j--)
                {
                  if (arr[j - 1] > arr[j])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j - 1];
                        arr[j - 1] = temp;
                    }
                    
                }
            }
            */
            //c2
            //arr = arr.OrderBy(i => i).ToArray();
            //arr = arr.OrderByDescending(i => i).ToArray();

            ////loc dk
            //List<int> rs = new List<int>();
            //foreach (var i in arr)
            //{
            //    if (i > 7) rs.Add(i);
            //}
            //arr = rs.ToArray();

            ////c2
            //arr = arr.Where(i => i > 7).OrderBy(i=>i).ToArray();
            //foreach (var i in arr)
            //{

            //    Console.WriteLine(i);
            //}

            //arr = arr.Select(i => i * 5).ToArray();

            //trung lap
            //List<int> rs = new List<int>();
            //foreach (var item in arr)
            //{
            //    if (!rs.Contains(item))
            //    {
            //        rs.Add(item);
            //    }
            //}
            //arr = arr.Distinct().ToArray();
            // var a= from i in arr where i>7 select i ; arr=a.toArray()

            //tinh tong
            int sum = arr.Sum();
            //dem so phan tu voi dk
            int count = arr.Count(i => i == 5);
            //max min
            int max = arr.Max();
            int min = arr.Min();

            Console.WriteLine(max+"\n"+min);
            Console.ReadLine();
        }
    }
}
