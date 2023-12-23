using NUnit.Framework;

namespace Tests;

public class Tests
{
    [Timeout(2000)]
    [TestCase(
        @"300 100
",
        @"Bat
",
        TestName = "{m}-1")]
    [TestCase(
        @"334 343
",
        @"Glove
",
        TestName = "{m}-2")]
    public void ATest(string input, string output)
    {
        Utility.InOutTest(Tasks.A.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"5 3 -1 6
",
        @"3
",
        TestName = "{m}-1")]
    [TestCase(
        @"-2 2 1 1
",
        @"0
",
        TestName = "{m}-2")]
    [TestCase(
        @"-177018739841739480 2436426 -80154573737296504 585335723211047198
",
        @"273142010859
",
        TestName = "{m}-3")]
    public void BTest(string input, string output)
    {
        Utility.InOutTest(Tasks.B.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"4 2
1 3
",
        @"2
",
        TestName = "{m}-1")]
    [TestCase(
        @"5 1
2
",
        @"0
",
        TestName = "{m}-2")]
    [TestCase(
        @"8 5
1 2 4 7 8
",
        @"2
",
        TestName = "{m}-3")]
    public void CTest(string input, string output)
    {
        Utility.InOutTest(Tasks.C.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"4 3
5 3 11 8
16
7
1000
",
        @"3
1
4
",
        TestName = "{m}-1")]
    [TestCase(
        @"6 6
1 2 3 4 5 6
1
2
3
4
5
6
",
        @"1
1
2
2
2
3
",
        TestName = "{m}-2")]
    [TestCase(
        @"2 2
1000000000 1000000000
200000000000000
1
",
        @"2
0
",
        TestName = "{m}-3")]
    public void DTest(string input, string output)
    {
        Utility.InOutTest(Tasks.D.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"3 3
##.
#.#
#..
",
        @"499122178
",
        TestName = "{m}-1")]
    [TestCase(
        @"4 5
..#..
.###.
#####
..#..
",
        @"598946613
",
        TestName = "{m}-2")]
    public void ETest(string input, string output)
    {
        Utility.InOutTest(Tasks.E.Solve, input, output);
    }
}
