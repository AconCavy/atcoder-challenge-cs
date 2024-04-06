using NUnit.Framework;

namespace Tests;

public class Tests
{
    [Timeout(2000)]
    [TestCase(
        @"7
",
        @"ooxooxo
",
        TestName = "{m}-1")]
    [TestCase(
        @"9
",
        @"ooxooxoox
",
        TestName = "{m}-2")]
    public void ATest(string input, string output)
    {
        Utility.InOutTest(Tasks.A.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"4
0 0
2 4
5 0
3 4
",
        @"3
3
1
1
",
        TestName = "{m}-1")]
    [TestCase(
        @"6
3 2
1 6
4 5
1 3
5 5
9 8
",
        @"6
6
6
6
6
4
",
        TestName = "{m}-2")]
    public void BTest(string input, string output)
    {
        Utility.InOutTest(Tasks.B.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"4
100 1
20 5
30 5
40 1
",
        @"40
",
        TestName = "{m}-1")]
    [TestCase(
        @"10
68 3
17 2
99 2
92 4
82 4
10 3
100 2
78 1
3 1
35 4
",
        @"35
",
        TestName = "{m}-2")]
    public void CTest(string input, string output)
    {
        Utility.InOutTest(Tasks.C.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"4 4
S...
#..#
#...
..#T
4
1 1 3
1 3 5
3 2 1
2 3 1
",
        @"Yes
",
        TestName = "{m}-1")]
    [TestCase(
        @"2 2
S.
T.
1
1 2 4
",
        @"No
",
        TestName = "{m}-2")]
    [TestCase(
        @"4 5
..#..
.S##.
.##T.
.....
3
3 1 5
1 2 3
2 2 1
",
        @"Yes
",
        TestName = "{m}-3")]
    public void DTest(string input, string output)
    {
        Utility.InOutTest(Tasks.D.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"4
1 2
1 3
2 4
1 1 1 2
",
        @"5
",
        TestName = "{m}-1")]
    [TestCase(
        @"2
2 1
1 1000000000
",
        @"1
",
        TestName = "{m}-2")]
    [TestCase(
        @"7
7 3
2 5
2 4
3 1
3 6
2 1
2 7 6 9 3 4 6
",
        @"56
",
        TestName = "{m}-3")]
    public void ETest(string input, string output)
    {
        Utility.InOutTest(Tasks.E.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"3 3
1 2 3
1 3 4
2 3 4
",
        @"1
",
        TestName = "{m}-1")]
    [TestCase(
        @"6 5
8 27 27 10 24
27 8 2 4 5
15 27 26 17 24
27 27 27 27 27
27 7 22 11 27
19 27 27 27 27
",
        @"5
",
        TestName = "{m}-2")]
    public void FTest(string input, string output)
    {
        Utility.InOutTest(Tasks.F.Solve, input, output);
    }
}
