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
            var nm = Console.ReadLine().Trim().Split(' ').Select(long.Parse).ToArray();
            var shops = new Pair[nm[0]];
            for (var i = 0; i < nm[0]; i++)
            {
                var ab = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
                shops[i] = new Pair { Price = ab[0], Count = ab[1] };
            }
            shops = shops.OrderBy(x => x.Price).ToArray();
            var money = 0L;
            var current = 0L;
            for (var i = 0; i < shops.Length; i++)
            {
                if (current < nm[1])
                {
                    current += shops[i].Count;
                    money += shops[i].Price * shops[i].Count;
                }
                if (current >= nm[1])
                {
                    money -= shops[i].Price * (current - nm[1]);
                    break;
                }
            }
            Console.WriteLine(money);
        }

        public struct Pair
        {
            public long Price { get; set; }
            public long Count { get; set; }
        }
    }
}
