using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayExample
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 5, 8, 13, 30, 4, 5, 6, 15, 30, 1 };
            //Sap xep
            /*
            for(int i = 0; i < arr.Length - 1; i++)
            {
                for(int j = i + 1; j < arr.Length; j++)
                {
                    if(arr[i] < arr[j])
                    {
                        int temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }*/
            //arr = arr.OrderByDescending(i => i).ToArray();

            //Loc dieu 
            /*
            List<int> rs = new List<int>();
            foreach(int i in arr)
            {
                if(i > 7)
                {
                    rs.Add(i);
                }
            }
            arr = rs.ToArray();
            */
            //arr = arr.Where(i => i > 7).OrderByDescending(i => i).ToArray();
            /*var a = from i in arr
                    where i > 7
                    select i;

            arr = a.ToArray();
            */

            //Truy xuat
            /*
            for(int i = 0; i < arr.Length; i++)
            {
                arr[i] *= 5;
            }
            */
            //arr = arr.Select(i => i * 5).ToArray();

            //Trung lap
            /*
            List<int> rs = new List<int>();
            foreach(int i in arr)
            {
                if (!rs.Contains(i))
                {
                    rs.Add(i);
                }
            }
            arr = rs.ToArray();
            */
            //arr = arr.Distinct().ToArray();

            //Sum
            //int sum = 0;
            /*
            foreach(int i in arr)
            {
                sum += i;
            }
            */
            //sum = arr.Sum();
            //Console.WriteLine("Sum = " + sum);

            //Dem (count)

            //int count = 0;
            /*
            foreach (int i in arr)
            {
                if (i == 5) count++;
            }
            */
            //count = arr.Count(i => i == 5);
            //Console.WriteLine("Count = " + count);

            //Max min
            int max, min;
            /*
            max = arr[0];
            min = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > max) max = arr[i];
                if (arr[i] < min) min = arr[i];
            }
            */
            max = arr.Max();
            min = arr.Min();
            Console.WriteLine("Min = {0}, Max = {1}", min, max);

            //arr = arr.Reverse().ToArray();

            foreach(int i in arr)
            {
                Console.WriteLine(i);
            }

            Console.ReadLine();
        }
    }
}
