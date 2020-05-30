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
            var answer = s[0] == 'A';
            if (answer)
            {
                var countC = 0;
                for (var i = 1; i < s.Length; i++)
                {
                    if (i > 1 && i < s.Length - 1 && s[i] == 'C') countC++;
                    else if ((s[i] - 'a') < 0) answer = false;
                }
                if (answer) answer = countC == 1;
            }

            Console.WriteLine(answer ? "AC" : "WA");
        }
    }
}
