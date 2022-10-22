using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"7 4
",
            @"0.571
")]
        [TestCase(
            @"7 3
",
            @"0.429
")]
        [TestCase(
            @"2 1
",
            @"0.500
")]
        [TestCase(
            @"10 10
",
            @"1.000
")]
        [TestCase(
            @"1 0
",
            @"0.000
")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3 4
#..#
.#.#
.#.#
",
            @"1 2 0 3
")]
        [TestCase(
            @"3 7
.......
.......
.......
",
            @"0 0 0 0 0 0 0
")]
        [TestCase(
            @"8 3
.#.
###
.#.
.#.
.##
..#
##.
.##
",
            @"2 7 4
")]
        [TestCase(
            @"5 47
.#..#..#####..#...#..#####..#...#...###...#####
.#.#...#.......#.#...#......##..#..#...#..#....
.##....#####....#....#####..#.#.#..#......#####
.#.#...#........#....#......#..##..#...#..#....
.#..#..#####....#....#####..#...#...###...#####
",
            @"0 5 1 2 2 0 0 5 3 3 3 3 0 0 1 1 3 1 1 0 0 5 3 3 3 3 0 0 5 1 1 1 5 0 0 3 2 2 2 2 0 0 5 3 3 3 3
")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"2
1 2
",
            @"0
1
1
2
2
")]
        [TestCase(
            @"4
1 3 5 2
",
            @"0
1
1
2
2
3
3
2
2
")]
        public void CTest(string input, string output)
        {
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3 -1 1
2 1 3
",
            @"Yes
")]
        [TestCase(
            @"5 2 0
2 2 2 2 2
",
            @"Yes
")]
        [TestCase(
            @"4 5 5
1 2 3 4
",
            @"No
")]
        [TestCase(
            @"3 2 7
2 7 4
",
            @"No
")]
        [TestCase(
            @"10 8 -7
6 10 4 1 5 9 8 6 5 1
",
            @"Yes
")]
        public void DTest(string input, string output)
        {
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"2 1
1 1
0 1
1 0
",
            @"2.5000000000
")]
        [TestCase(
            @"2 1
1 1
0 1
100 0
",
            @"3.4142135624
")]
        [TestCase(
            @"1 2
4 4
1 0
0 1
",
            @"4.3713203436
")]
        public void ETest(string input, string output)
        {
            Utility.InOutTest(Tasks.E.Solve, input, output, 1e-6);
        }
    }
}
