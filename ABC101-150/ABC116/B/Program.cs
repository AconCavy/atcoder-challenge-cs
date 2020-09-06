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
            var s = long.Parse(Console.ReadLine());
            Func<long, long> f = n => n % 2 == 0 ? n / 2 : 3 * n + 1;
            var answer = 0L;
            var i = 0L;
            var flag = false;
            var loop = s <= 2 ? s : 4;
            while (true)
            {
                if (s == loop)
                {
                    if (flag)
                    {
                        answer = i + 1;
                        break;
                    }
                    else
                    {
                        flag = true;
                    }
                }
                s = f(s);
                i++;
            }
            Console.WriteLine(answer);
        }
    }
}
