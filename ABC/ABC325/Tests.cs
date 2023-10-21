using NUnit.Framework;

namespace Tests;

public class Tests
{
    [Timeout(2000)]
    [TestCase(
        @"Takahashi Chokudai
",
        @"Takahashi san
",
        TestName = "{m}-1")]
    [TestCase(
        @"K Eyence
",
        @"K san
",
        TestName = "{m}-2")]
    public void ATest(string input, string output)
    {
        Utility.InOutTest(Tasks.A.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"3
5 0
3 3
2 18
",
        @"8
",
        TestName = "{m}-1")]
    [TestCase(
        @"2
1 10
1000000 20
",
        @"1000000
",
        TestName = "{m}-2")]
    [TestCase(
        @"6
31 3
20 8
11 5
4 3
47 14
1 18
",
        @"67
",
        TestName = "{m}-3")]
    public void BTest(string input, string output)
    {
        Utility.InOutTest(Tasks.B.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"5 6
.##...
...#..
....##
#.#...
..#...
",
        @"3
",
        TestName = "{m}-1")]
    [TestCase(
        @"4 2
..
..
..
..
",
        @"0
",
        TestName = "{m}-2")]
    [TestCase(
        @"5 47
.#..#..#####..#...#..#####..#...#...###...#####
.#.#...#.......#.#...#......##..#..#...#..#....
.##....#####....#....#####..#.#.#..#......#####
.#.#...#........#....#......#..##..#...#..#....
.#..#..#####....#....#####..#...#...###...#####
",
        @"7
",
        TestName = "{m}-3")]
    public void CTest(string input, string output)
    {
        Utility.InOutTest(Tasks.C.Solve, input, output);
    }

    [Timeout(3000)]
    [TestCase(
        @"5
1 1
1 1
2 1
1 2
1 4
",
        @"4
",
        TestName = "{m}-1")]
    [TestCase(
        @"2
1 1
1000000000000000000 1000000000000000000
",
        @"2
",
        TestName = "{m}-2")]
    [TestCase(
        @"10
4 1
1 2
1 4
3 2
5 1
5 1
4 1
2 1
4 1
2 4
",
        @"6
",
        TestName = "{m}-3")]
    public void DTest(string input, string output)
    {
        Utility.InOutTest(Tasks.D.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"4 8 5 13
0 6 2 15
6 0 3 5
2 3 0 13
15 5 13 0
",
        @"78
",
        TestName = "{m}-1")]
    [TestCase(
        @"3 1 1000000 1000000
0 10 1
10 0 10
1 10 0
",
        @"1
",
        TestName = "{m}-2")]
    [TestCase(
        @"5 954257 954213 814214
0 84251 214529 10017 373342
84251 0 91926 32336 164457
214529 91926 0 108914 57762
10017 32336 108914 0 234705
373342 164457 57762 234705 0
",
        @"168604826785
",
        TestName = "{m}-3")]
    public void ETest(string input, string output)
    {
        Utility.InOutTest(Tasks.E.Solve, input, output);
    }
}
