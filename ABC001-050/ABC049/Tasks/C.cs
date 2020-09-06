using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class C
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
            var S = Console.ReadLine();
            var t = new[] { "remaerd", "resare", "maerd", "esare" };
            var answer = true;
            var reversed = new string(S.Reverse().ToArray());
            var current = 0;
            while (answer)
            {
                if (current == S.Length) break;
                // Console.WriteLine(current);
                var tmp = false;
                for (var i = 0; i < 4; i++)
                {
                    if (reversed.IndexOf(t[i], current) == current)
                    {
                        current = current += t[i].Length;
                        tmp = true;
                        break;
                    }
                }
                if (!tmp && current < S.Length) answer = false;
            }

            Console.WriteLine(answer ? "YES" : "NO");
        }
    }
}
