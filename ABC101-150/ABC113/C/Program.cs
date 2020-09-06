using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace C
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
            var pys = new PY[nm[1]];
            for (var i = 0; i < pys.Length; i++)
            {
                var py = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                pys[i] = new PY { P = py[0], Y = py[1] };
            }
            var tmp = pys.OrderBy(x => x.P).ThenBy(x => x.Y).ToArray();
            var before = 0;
            var num = 1;
            for (var i = 0; i < tmp.Length; i++)
            {
                if (tmp[i].P != before)
                {
                    before = tmp[i].P;
                    num = 1;
                }
                tmp[i].Order = num++;
            }
            for (var i = 0; i < pys.Length; i++)
            {
                Console.WriteLine(pys[i].P.ToString("000000") + pys[i].Order.ToString("000000"));
            }
        }

        public class PY
        {
            public int Order { get; set; }
            public int P { get; set; }
            public int Y { get; set; }
        }
    }
}
