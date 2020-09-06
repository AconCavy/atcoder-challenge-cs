using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasks
{
    public class B
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
            var tmp = new char[S.Length];
            var j = 0;
            for (var i = 0; i < S.Length; i++)
            {
                switch (S[i])
                {
                    case '0': tmp[j++] = '0'; break;
                    case '1': tmp[j++] = '1'; break;
                    case 'B': tmp[j > 0 ? --j : j] = '-'; break;
                }
            }

            var answer = "";
            for (var i = 0; i < tmp.Length; i++)
            {
                if (tmp[i] == '-' || tmp[i] == 0) break;
                answer += tmp[i];
            }
            Console.WriteLine(answer);
        }
    }
}
