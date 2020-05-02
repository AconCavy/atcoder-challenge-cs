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
            var s = Console.ReadLine();
            var first = int.Parse(s.Substring(0, 2));
            var last = int.Parse(s.Substring(2, 2));
            var isYYMM = (0 < last && last < 13);
            var isMMYY = (0 < first && first < 13);
            if (isYYMM)
            {
                if (isMMYY) Console.WriteLine("AMBIGUOUS");
                else Console.WriteLine("YYMM");
            }
            else
            {
                if (isMMYY) Console.WriteLine("MMYY");
                else Console.WriteLine("NA");
            }
        }
    }
}
