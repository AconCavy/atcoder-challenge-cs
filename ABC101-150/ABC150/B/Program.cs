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
            var n = int.Parse(Console.ReadLine());
            var s = Console.ReadLine();
            Console.WriteLine(CountOf(s, "ABC"));
        }

        static int CountOf(string target, string value)
        {
            var editStr = target;
            var count = 0;
            var index = 0;
            while (true)
            {
                index = editStr.IndexOf(value);
                if (index < 0) break;
                count++;
                if (editStr.Length > 1) editStr = editStr.Substring(index + 1);
            }
            return count;
        }
    }
}
