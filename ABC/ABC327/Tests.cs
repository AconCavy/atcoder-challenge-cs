using NUnit.Framework;

namespace Tests;

public class Tests
{
    [Timeout(2000)]
    [TestCase(
        @"3
abc
",
        @"Yes
",
        TestName = "{m}-1")]
    [TestCase(
        @"2
ba
",
        @"Yes
",
        TestName = "{m}-2")]
    [TestCase(
        @"7
atcoder
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
        @"27
",
        @"3
",
        TestName = "{m}-1")]
    [TestCase(
        @"100
",
        @"-1
",
        TestName = "{m}-2")]
    [TestCase(
        @"10000000000
",
        @"10
",
        TestName = "{m}-3")]
    public void BTest(string input, string output)
    {
        Utility.InOutTest(Tasks.B.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"1 2 3 4 5 6 7 8 9
4 5 6 7 8 9 1 2 3
7 8 9 1 2 3 4 5 6
2 3 4 5 6 7 8 9 1
5 6 7 8 9 1 2 3 4
8 9 1 2 3 4 5 6 7
3 4 5 6 7 8 9 1 2
6 7 8 9 1 2 3 4 5
9 1 2 3 4 5 6 7 8
",
        @"Yes
",
        TestName = "{m}-1")]
    [TestCase(
        @"1 2 3 4 5 6 7 8 9
2 3 4 5 6 7 8 9 1
3 4 5 6 7 8 9 1 2
4 5 6 7 8 9 1 2 3
5 6 7 8 9 1 2 3 4
6 7 8 9 1 2 3 4 5
7 8 9 1 2 3 4 5 6
8 9 1 2 3 4 5 6 7
9 1 2 3 4 5 6 7 8
",
        @"No
",
        TestName = "{m}-2")]
    [TestCase(
        @"1 2 3 4 5 6 7 8 9
4 5 6 7 8 9 1 2 3
7 8 9 1 2 3 4 5 6
1 2 3 4 5 6 7 8 9
4 5 6 7 8 9 1 2 3
7 8 9 1 2 3 4 5 6
1 2 3 4 5 6 7 8 9
4 5 6 7 8 9 1 2 3
7 8 9 1 2 3 4 5 6
",
        @"No
",
        TestName = "{m}-3")]
    public void CTest(string input, string output)
    {
        Utility.InOutTest(Tasks.C.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"3 2
1 2
2 3
",
        @"Yes
",
        TestName = "{m}-1")]
    [TestCase(
        @"3 3
1 2 3
2 3 1
",
        @"No
",
        TestName = "{m}-2")]
    [TestCase(
        @"10 1
1
1
",
        @"No
",
        TestName = "{m}-3")]
    [TestCase(
        @"7 8
1 6 2 7 5 4 2 2
3 2 7 2 1 2 3 3
",
        @"Yes
",
        TestName = "{m}-4")]
    public void DTest(string input, string output)
    {
        Utility.InOutTest(Tasks.D.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"3
1000 600 1200
",
        @"256.735020470879931
",
        TestName = "{m}-1")]
    [TestCase(
        @"3
600 1000 1200
",
        @"261.423219407873376
",
        TestName = "{m}-2")]
    [TestCase(
        @"1
100
",
        @"-1100.000000000000000
",
        TestName = "{m}-3")]
    public void ETest(string input, string output)
    {
        Utility.InOutTest(Tasks.E.Solve, input, output, 1e-6);
    }

    [Timeout(2000)]
    [TestCase(
        @"8 4 3
1 1
3 4
6 4
5 2
4 2
4 3
5 5
7 3
",
        @"5
",
        TestName = "{m}-1")]
    public void FTest(string input, string output)
    {
        Utility.InOutTest(Tasks.F.Solve, input, output);
    }
}
