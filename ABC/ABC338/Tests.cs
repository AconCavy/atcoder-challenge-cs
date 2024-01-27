using NUnit.Framework;

namespace Tests;

public class Tests
{
    [Timeout(2000)]
    [TestCase(
        @"Capitalized
",
        @"Yes
",
        TestName = "{m}-1")]
    [TestCase(
        @"AtCoder
",
        @"No
",
        TestName = "{m}-2")]
    [TestCase(
        @"yes
",
        @"No
",
        TestName = "{m}-3")]
    [TestCase(
        @"A
",
        @"Yes
",
        TestName = "{m}-4")]
    public void ATest(string input, string output)
    {
        Utility.InOutTest(Tasks.A.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"frequency
",
        @"e
",
        TestName = "{m}-1")]
    [TestCase(
        @"atcoder
",
        @"a
",
        TestName = "{m}-2")]
    [TestCase(
        @"pseudopseudohypoparathyroidism
",
        @"o
",
        TestName = "{m}-3")]
    public void BTest(string input, string output)
    {
        Utility.InOutTest(Tasks.B.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"2
800 300
100 100
200 10
",
        @"5
",
        TestName = "{m}-1")]
    [TestCase(
        @"2
800 300
100 0
0 10
",
        @"38
",
        TestName = "{m}-2")]
    [TestCase(
        @"2
800 300
801 300
800 301
",
        @"0
",
        TestName = "{m}-3")]
    [TestCase(
        @"10
1000000 1000000 1000000 1000000 1000000 1000000 1000000 1000000 1000000 1000000
0 1 2 3 4 5 6 7 8 9
9 8 7 6 5 4 3 2 1 0
",
        @"222222
",
        TestName = "{m}-4")]
    public void CTest(string input, string output)
    {
        Utility.InOutTest(Tasks.C.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"3 3
1 3 2
",
        @"2
",
        TestName = "{m}-1")]
    [TestCase(
        @"4 5
2 4 2 4 2
",
        @"8
",
        TestName = "{m}-2")]
    [TestCase(
        @"163054 10
62874 19143 77750 111403 29327 56303 6659 18896 64175 26369
",
        @"390009
",
        TestName = "{m}-3")]
    public void DTest(string input, string output)
    {
        Utility.InOutTest(Tasks.D.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"3
1 3
4 2
5 6
",
        @"Yes
",
        TestName = "{m}-1")]
    [TestCase(
        @"3
6 1
4 3
2 5
",
        @"No
",
        TestName = "{m}-2")]
    [TestCase(
        @"4
2 4
3 7
8 6
5 1
",
        @"Yes
",
        TestName = "{m}-3")]
    public void ETest(string input, string output)
    {
        Utility.InOutTest(Tasks.E.Solve, input, output);
    }
}
