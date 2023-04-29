using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"3 125 175
200 300 400
",
            @"2
",
            TestName = "{m}-1")]
        [TestCase(
            @"1 1 1
2
",
            @"1
",
            TestName = "{m}-2")]
        [TestCase(
            @"5 123 456
135 246 357 468 579
",
            @"5
",
            TestName = "{m}-3")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"4 3
..#
...
.#.
...
#..
...
.#.
...
",
            @"Yes
",
            TestName = "{m}-1")]
        [TestCase(
            @"3 2
##
##
#.
..
#.
#.
",
            @"No
",
            TestName = "{m}-2")]
        [TestCase(
            @"4 5
#####
.#...
.##..
..##.
...##
#...#
#####
...#.
",
            @"Yes
",
            TestName = "{m}-3")]
        [TestCase(
            @"10 30
..........##########..........
..........####....###.....##..
.....##....##......##...#####.
....####...##..#####...##...##
...##..##..##......##..##....#
#.##....##....##...##..##.....
..##....##.##..#####...##...##
..###..###..............##.##.
.#..####..#..............###..
#..........##.................
................#..........##.
######....................####
....###.....##............####
.....##...#####......##....##.
.#####...##...##....####...##.
.....##..##....#...##..##..##.
##...##..##.....#.##....##....
.#####...##...##..##....##.##.
..........##.##...###..###....
...........###...#..####..#...
",
            @"Yes
",
            TestName = "{m}-4")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"5 9
#.#.#...#
.#...#.#.
#.#...#..
.....#.#.
....#...#
",
            @"1 1 0 0 0
",
            TestName = "{m}-1")]
        [TestCase(
            @"3 3
...
...
...
",
            @"0 0 0
",
            TestName = "{m}-2")]
        [TestCase(
            @"3 16
#.#.....#.#..#.#
.#.......#....#.
#.#.....#.#..#.#
",
            @"3 0 0
",
            TestName = "{m}-3")]
        [TestCase(
            @"15 20
#.#..#.............#
.#....#....#.#....#.
#.#....#....#....#..
........#..#.#..#...
#.....#..#.....#....
.#...#....#...#..#.#
..#.#......#.#....#.
...#........#....#.#
..#.#......#.#......
.#...#....#...#.....
#.....#..#.....#....
........#.......#...
#.#....#....#.#..#..
.#....#......#....#.
#.#..#......#.#....#
",
            @"5 0 1 0 0 0 1 0 0 0 0 0 0 0 0
",
            TestName = "{m}-4")]
        public void CTest(string input, string output)
        {
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [Timeout(3000)]
        [TestCase(
            @"1000
",
            @"3
",
            TestName = "{m}-1")]
        [TestCase(
            @"1000000000000
",
            @"2817785
",
            TestName = "{m}-2")]
        public void DTest(string input, string output)
        {
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"6
",
            @"239578645
",
            TestName = "{m}-1")]
        [TestCase(
            @"7
",
            @"0
",
            TestName = "{m}-2")]
        [TestCase(
            @"300
",
            @"183676961
",
            TestName = "{m}-3")]
        [TestCase(
            @"979552051200000000
",
            @"812376310
",
            TestName = "{m}-4")]
        public void ETest(string input, string output)
        {
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }
    }
}
