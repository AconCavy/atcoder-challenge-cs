using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"-1 -1
-1 2
3 2
",
            @"3 -1
")]
        [TestCase(
            @"-60 -40
-60 -80
-20 -80
",
            @"-20 -40
")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3 4
",
            @"0.600000000000 0.800000000000
")]
        [TestCase(
            @"1 0
",
            @"1.000000000000 0.000000000000
")]
        [TestCase(
            @"246 402
",
            @"0.521964870245 0.852966983083
")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output, 1e-6);
        }

        [Timeout(2000)]
        [TestCase(
            @"5 4 7
8 3 10 5 13
",
            @"12
")]
        [TestCase(
            @"5 100 7
8 3 10 5 13
",
            @"0
")]
        [TestCase(
            @"20 815 60
2066 3193 2325 4030 3725 1669 1969 763 1653 159 5311 5341 4671 2374 4513 285 810 742 2981 202
",
            @"112
")]
        public void CTest(string input, string output)
        {
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"9
",
            @"15
")]
        [TestCase(
            @"0
",
            @"0
")]
        [TestCase(
            @"999999999989449206
",
            @"1000000000000000000
")]
        public void DTest(string input, string output)
        {
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"5
1 3
3 5
....#
...#.
.....
.#...
#....
",
            @"3
")]
        [TestCase(
            @"4
3 2
4 2
....
....
....
....
",
            @"-1
")]
        [TestCase(
            @"18
18 1
1 18
..................
.####.............
.#..#..####.......
.####..#..#..####.
.#..#..###...#....
.#..#..#..#..#....
.......####..#....
.............####.
..................
..................
.####.............
....#..#..#.......
.####..#..#..####.
.#.....####..#....
.####.....#..####.
..........#..#..#.
.............####.
..................
",
            @"9
")]
        public void ETest(string input, string output)
        {
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }
    }
}
