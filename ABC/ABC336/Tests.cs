using NUnit.Framework;

namespace Tests;

public class Tests
{
    [Timeout(2000)]
    [TestCase(
        @"3
",
        @"Looong
",
        TestName = "{m}-1")]
    [TestCase(
        @"1
",
        @"Long
",
        TestName = "{m}-2")]
    public void ATest(string input, string output)
    {
        Utility.InOutTest(Tasks.A.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"2024
",
        @"3
",
        TestName = "{m}-1")]
    [TestCase(
        @"18
",
        @"1
",
        TestName = "{m}-2")]
    [TestCase(
        @"5
",
        @"0
",
        TestName = "{m}-3")]
    public void BTest(string input, string output)
    {
        Utility.InOutTest(Tasks.B.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"8
",
        @"24
",
        TestName = "{m}-1")]
    [TestCase(
        @"133
",
        @"2024
",
        TestName = "{m}-2")]
    [TestCase(
        @"31415926535
",
        @"2006628868244228
",
        TestName = "{m}-3")]
    public void CTest(string input, string output)
    {
        Utility.InOutTest(Tasks.C.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"5
2 2 3 1 1
",
        @"2
",
        TestName = "{m}-1")]
    [TestCase(
        @"5
1 2 3 4 5
",
        @"3
",
        TestName = "{m}-2")]
    [TestCase(
        @"1
1000000000
",
        @"1
",
        TestName = "{m}-3")]
    public void DTest(string input, string output)
    {
        Utility.InOutTest(Tasks.D.Solve, input, output);
    }

    [Timeout(10000)]
    [TestCase(
        @"20
",
        @"13
",
        TestName = "{m}-1")]
    [TestCase(
        @"2024
",
        @"409
",
        TestName = "{m}-2")]
    [TestCase(
        @"9876543210
",
        @"547452239
",
        TestName = "{m}-3")]
    public void ETest(string input, string output)
    {
        Utility.InOutTest(Tasks.E.Solve, input, output);
    }

    [Timeout(5000)]
    [TestCase(
        @"3 3
9 4 3
2 1 8
7 6 5
",
        @"2
",
        TestName = "{m}-1")]
    [TestCase(
        @"4 6
15 18 1 14 3 4
23 24 19 8 9 12
13 2 17 6 5 16
21 22 7 20 11 10
",
        @"-1
",
        TestName = "{m}-2")]
    [TestCase(
        @"4 6
1 4 13 16 15 18
21 20 9 12 23 10
17 14 5 6 3 2
11 22 7 24 19 8
",
        @"20
",
        TestName = "{m}-3")]
    [TestCase(
        @"4 3
1 2 3
4 5 6
7 8 9
10 11 12
",
        @"0
",
        TestName = "{m}-4")]
    public void FTest(string input, string output)
    {
        Utility.InOutTest(Tasks.F.Solve, input, output);
    }
}
