using NUnit.Framework;

namespace Tests;

public class Tests
{
    [Timeout(2000)]
    [TestCase(
        @"ABC349
",
        @"Yes
",
        TestName = "{m}-1")]
    [TestCase(
        @"ABC350
",
        @"No
",
        TestName = "{m}-2")]
    [TestCase(
        @"ABC316
",
        @"No
",
        TestName = "{m}-3")]
    public void ATest(string input, string output)
    {
        Utility.InOutTest(Tasks.A.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"30 6
2 9 18 27 18 9
",
        @"28
",
        TestName = "{m}-1")]
    [TestCase(
        @"1 7
1 1 1 1 1 1 1
",
        @"0
",
        TestName = "{m}-2")]
    [TestCase(
        @"9 20
9 5 1 2 2 2 8 9 2 1 6 2 6 5 8 7 8 5 9 8
",
        @"5
",
        TestName = "{m}-3")]
    public void BTest(string input, string output)
    {
        Utility.InOutTest(Tasks.B.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"5
3 4 1 2 5
",
        @"2
1 3
2 4
",
        TestName = "{m}-1")]
    [TestCase(
        @"4
1 2 3 4
",
        @"0
",
        TestName = "{m}-2")]
    [TestCase(
        @"3
3 1 2
",
        @"2
1 2
2 3
",
        TestName = "{m}-3")]
    public void CTest(string input, string output)
    {
        Utility.InOutTest(Tasks.C.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"4 3
1 2
2 3
1 4
",
        @"3
",
        TestName = "{m}-1")]
    [TestCase(
        @"3 0
",
        @"0
",
        TestName = "{m}-2")]
    [TestCase(
        @"10 8
1 2
2 3
3 4
4 5
6 7
7 8
8 9
9 10
",
        @"12
",
        TestName = "{m}-3")]
    public void DTest(string input, string output)
    {
        Utility.InOutTest(Tasks.D.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"3 2 10 20
",
        @"20.000000000000000
",
        TestName = "{m}-1")]
    [TestCase(
        @"3 2 20 20
",
        @"32.000000000000000
",
        TestName = "{m}-2")]
    [TestCase(
        @"314159265358979323 4 223606797 173205080
",
        @"6418410657.7408381
",
        TestName = "{m}-3")]
    public void ETest(string input, string output)
    {
        Utility.InOutTest(Tasks.E.Solve, input, output, 1e-6);
    }
}
