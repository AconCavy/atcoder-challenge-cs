using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"5
ACABB
",
            @"4
",
            TestName = "{m}-1")]
        [TestCase(
            @"4
CABC
",
            @"3
",
            TestName = "{m}-2")]
        [TestCase(
            @"30
AABABBBABABBABABCABACAABCBACCA
",
            @"17
",
            TestName = "{m}-3")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3 5
xooox
oooxx
oooxo
",
            @"2
",
            TestName = "{m}-1")]
        [TestCase(
            @"3 3
oxo
oxo
oxo
",
            @"1
",
            TestName = "{m}-2")]
        [TestCase(
            @"3 3
oox
oxo
xoo
",
            @"0
",
            TestName = "{m}-3")]
        [TestCase(
            @"1 7
ooooooo
",
            @"7
",
            TestName = "{m}-4")]
        [TestCase(
            @"5 15
oxooooooooooooo
oxooxooooooooox
oxoooooooooooox
oxxxooooooxooox
oxooooooooxooox
",
            @"5
",
            TestName = "{m}-5")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"7
6 7 2 1 3 4 5
",
            @"3
4 1 6
",
            TestName = "{m}-1")]
        [TestCase(
            @"2
2 1
",
            @"2
1 2
",
            TestName = "{m}-2")]
        [TestCase(
            @"8
3 7 4 7 3 3 8 2
",
            @"3
2 7 8
",
            TestName = "{m}-3")]
        public void CTest(string input, string output)
        {
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"6 6
######
#....#
#.#..#
#..#.#
#....#
######
",
            @"12
",
            TestName = "{m}-1")]
        [TestCase(
            @"21 25
#########################
#..............###...####
#..............#..#...###
#........###...#...#...##
#........#..#..#........#
#...##...#..#..#...#....#
#..#..#..###...#..#.....#
#..#..#..#..#..###......#
#..####..#..#...........#
#..#..#..###............#
#..#..#.................#
#........##.............#
#.......#..#............#
#..........#....#.......#
#........###...##....#..#
#..........#..#.#...##..#
#.......#..#....#..#.#..#
##.......##.....#....#..#
###.............#....#..#
####.................#..#
#########################
",
            @"215
",
            TestName = "{m}-2")]
        public void DTest(string input, string output)
        {
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"2 3 1
2 3
",
            @"6
",
            TestName = "{m}-1")]
        [TestCase(
            @"3 2 6
1 1
1 2
2 1
2 2
3 1
3 2
",
            @"0
",
            TestName = "{m}-2")]
        [TestCase(
            @"1 1 0
",
            @"1
",
            TestName = "{m}-3")]
        [TestCase(
            @"3000 3000 0
",
            @"9004500500
",
            TestName = "{m}-4")]
        public void ETest(string input, string output)
        {
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"2 2
.#
..
",
            @"3
",
            TestName = "{m}-1")]
        [TestCase(
            @"5 5
....#
...#.
..#..
.#.#.
#...#
",
            @"92
",
            TestName = "{m}-2")]
        [TestCase(
            @"25 25
.........................
.........................
.........................
.........................
.........................
.........................
.........................
.........................
.........................
.........................
.........................
.........................
.........................
.........................
.........................
.........................
.........................
.........................
.........................
.........................
.........................
.........................
.........................
.........................
.........................
",
            @"604936632
",
            TestName = "{m}-3")]
        public void FTest(string input, string output)
        {
            Utility.InOutTest(Tasks.F.Solve, input, output);
        }
    }
}
