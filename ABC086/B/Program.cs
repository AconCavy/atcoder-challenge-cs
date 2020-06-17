using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
            var ab = Console.ReadLine().Trim().Split(' ');
            var val = int.Parse(ab[0] + ab[1]);
            var tmp = (int)Math.Sqrt(val);
            Console.WriteLine(tmp * tmp == val ? "Yes" : "No");
        }
    }
}
