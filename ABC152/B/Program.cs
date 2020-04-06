using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace B
{
    public class Program
    {
        static void Main(string[] args)
        {
            var sw = new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false };
            Console.SetOut(sw);
            Solve();
            Console.Out.Flush();
        }

        public static void Solve()
        {
            var ab = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var sb = new StringBuilder();
            var array = new string[2];
            for (var i = 0; i < ab[1]; i++)
            {
                sb.Append(ab[0]);
            }
            array[0] = sb.ToString();
            sb.Clear();
            for (var i = 0; i < ab[0]; i++)
            {
                sb.Append(ab[1]);
            }
            array[1] = sb.ToString();
            Array.Sort(array);
            Console.WriteLine(array[0]);
        }
    }
}
