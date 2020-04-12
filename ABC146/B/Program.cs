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
            var n = byte.Parse(Console.ReadLine());
            var s = Console.ReadLine().ToCharArray();
            for (var i = 0; i < s.Length; i++)
            {
                var next = Convert.ToByte(s[i]) + n;
                if (next > Convert.ToByte('Z')) next -= 26;
                s[i] = Convert.ToChar(next);
            }
            Console.WriteLine(new string(s));
        }
    }
}
