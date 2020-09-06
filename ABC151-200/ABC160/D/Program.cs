using System;
using System.Linq;

namespace D
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var n = input[0];
            var x = input[1];
            var y = input[2];
            var diff = y - x;
            var flag = false;
            Func<int, bool> isInRange = val => x < val && val < y;

            for (var k = 1; k < n; k++)
            {
                if (flag)
                {
                    Console.WriteLine(0);
                    continue;
                }

                var count = 0;
                if (k == 1)
                {
                    count = n;
                }
                else if (k == n - 1)
                {
                    count = 0;
                }
                else
                {
                    for (var start = 1; start <= n - k; start++)
                    {
                        var end = start + k;
                        if (isInRange(start) && !isInRange(end))
                        {

                        }

                        if (end > n)
                        {
                            break;
                        }
                        count++;
                    }
                }

                if (count == 0)
                {
                    flag = true;
                }

                Console.WriteLine(count);
            }

        }
    }
}
