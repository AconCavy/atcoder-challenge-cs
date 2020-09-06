using System;
using System.Collections.Generic;
using System.Linq;

namespace C
{
    public class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var dict = new Dictionary<string, int>();
            var max = 1;

            for (var i = 0; i < n; i++)
            {
                var s = Console.ReadLine();
                int count;
                if (dict.TryGetValue(s, out count))
                {
                    dict[s] = count + 1;
                    max = Math.Max(max, count + 1);
                }
                else
                {
                    dict.Add(s, 1);
                }
            }
            var result = dict.Where(x => x.Value == max).Select(x => x.Key).ToList();
            result.Sort(StringComparer.Ordinal);
            Console.WriteLine(string.Join("\n", result));
        }
    }

}
