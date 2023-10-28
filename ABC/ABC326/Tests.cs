using NUnit.Framework;

namespace Tests;

public class Tests
{
    [Timeout(2000)]
    [TestCase(
        @"1 4
",
        @"No
",
        TestName = "{m}-1")]
    [TestCase(
        @"99 96
",
        @"Yes
",
        TestName = "{m}-2")]
    [TestCase(
        @"100 1
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
        @"320
",
        @"326
",
        TestName = "{m}-1")]
    [TestCase(
        @"144
",
        @"144
",
        TestName = "{m}-2")]
    [TestCase(
        @"516
",
        @"600
",
        TestName = "{m}-3")]
    public void BTest(string input, string output)
    {
        Utility.InOutTest(Tasks.B.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"8 6
2 3 5 7 11 13 17 19
",
        @"4
",
        TestName = "{m}-1")]
    [TestCase(
        @"10 1
3 1 4 1 5 9 2 6 5 3
",
        @"2
",
        TestName = "{m}-2")]
    [TestCase(
        @"10 998244353
100000007 0 1755647 998244353 495 1000000000 1755648 503 1755649 998244853
",
        @"7
",
        TestName = "{m}-3")]
    public void CTest(string input, string output)
    {
        Utility.InOutTest(Tasks.C.Solve, input, output);
    }

    [Timeout(4000)]
    [TestCase(
        @"5
ABCBC
ACAAB
",
        @"Yes
AC..B
.BA.C
C.BA.
BA.C.
..CBA
",
        TestName = "{m}-1")]
    [TestCase(
        @"3
AAA
BBB
",
        @"No
",
        TestName = "{m}-2")]
    public void DTest(string input, string output)
    {
        Utility.InOutTest(Tasks.D.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"3
3 2 6
",
        @"776412280
",
        TestName = "{m}-1")]
    [TestCase(
        @"1
998244352
",
        @"998244352
",
        TestName = "{m}-2")]
    [TestCase(
        @"9
3 14 159 2653 58979 323846 2643383 27950288 419716939
",
        @"545252774
",
        TestName = "{m}-3")]
    public void ETest(string input, string output)
    {
        Utility.InOutTest(Tasks.E.Solve, input, output);
    }
}
