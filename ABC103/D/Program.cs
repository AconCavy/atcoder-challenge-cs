using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace D
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
            var nm = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var n = nm[0];
            var m = nm[1];
            var war = new Tuple<int, int>[m];
            for (var i = 0; i < war.Length; i++)
            {
                var ab = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                war[i] = new Tuple<int, int>(ab[0], ab[1]);
            }
            war = war.OrderBy(x => x.Item2).ToArray();
            var answer = 0;
            var right = -1;
            for (var i = 0; i < war.Length; i++)
            {
                if (right <= war[i].Item1)
                {
                    answer++;
                    right = war[i].Item2;
                }
            }
            Console.WriteLine(answer);
        }
    }
}
