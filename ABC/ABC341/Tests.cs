using NUnit.Framework;

namespace Tests;

public class Tests
{
    [Timeout(2000)]
    [TestCase(
        @"4
",
        @"101010101
",
        TestName = "{m}-1")]
    [TestCase(
        @"1
",
        @"101
",
        TestName = "{m}-2")]
    [TestCase(
        @"10
",
        @"101010101010101010101
",
        TestName = "{m}-3")]
    public void ATest(string input, string output)
    {
        Utility.InOutTest(Tasks.A.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"4
5 7 0 3
2 2
4 3
5 2
",
        @"5
",
        TestName = "{m}-1")]
    [TestCase(
        @"10
32 6 46 9 37 8 33 14 31 5
5 5
3 1
4 3
2 2
3 2
3 2
4 4
3 3
3 1
",
        @"45
",
        TestName = "{m}-2")]
    public void BTest(string input, string output)
    {
        Utility.InOutTest(Tasks.B.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"6 7 5
LULDR
#######
#...#.#
##...##
#.#...#
#...#.#
#######
",
        @"2
",
        TestName = "{m}-1")]
    [TestCase(
        @"13 16 9
ULURDLURD
################
##..##.#..####.#
###.#..#.....#.#
#..##..#####.###
#...#..#......##
###.##.#..#....#
##.#####....##.#
###.###.#.#.#..#
######.....##..#
#...#.#.######.#
##..###..#..#.##
#...#.#.#...#..#
################
",
        @"6
",
        TestName = "{m}-2")]
    public void CTest(string input, string output)
    {
        Utility.InOutTest(Tasks.C.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"2 3 5
",
        @"9
",
        TestName = "{m}-1")]
    [TestCase(
        @"1 2 3
",
        @"5
",
        TestName = "{m}-2")]
    [TestCase(
        @"100000000 99999999 10000000000
",
        @"500000002500000000
",
        TestName = "{m}-3")]
    public void DTest(string input, string output)
    {
        Utility.InOutTest(Tasks.D.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"5 6
10100
2 1 3
2 1 5
1 1 4
2 1 5
1 3 3
2 2 4
",
        @"Yes
No
Yes
No
",
        TestName = "{m}-1")]
    [TestCase(
        @"1 2
1
1 1 1
2 1 1
",
        @"Yes
",
        TestName = "{m}-2")]
    public void ETest(string input, string output)
    {
        Utility.InOutTest(Tasks.E.Solve, input, output);
    }
}
