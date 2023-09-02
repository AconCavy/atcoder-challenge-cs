using NUnit.Framework;

namespace Tests;

public class Tests
{
    [Timeout(2000)]
    [TestCase(
        @"13 3 5
",
        @"3
",
        TestName = "{m}-1")]
    [TestCase(
        @"5 6 6
",
        @"0
",
        TestName = "{m}-2")]
    [TestCase(
        @"200000 314 318
",
        @"628
",
        TestName = "{m}-3")]
    public void ATest(string input, string output)
    {
        Utility.InOutTest(Tasks.A.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"3
0 5 1 3
1 4 0 5
2 5 2 4
",
        @"20
",
        TestName = "{m}-1")]
    [TestCase(
        @"2
0 100 0 100
0 100 0 100
",
        @"10000
",
        TestName = "{m}-2")]
    [TestCase(
        @"3
0 1 0 1
0 3 0 5
5 10 0 10
",
        @"65
",
        TestName = "{m}-3")]
    public void BTest(string input, string output)
    {
        Utility.InOutTest(Tasks.B.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"5 2 10
7 1 6 3 6
",
        @"20
",
        TestName = "{m}-1")]
    [TestCase(
        @"3 1 10
1 2 3
",
        @"6
",
        TestName = "{m}-2")]
    [TestCase(
        @"8 3 1000000000
1000000000 1000000000 1000000000 1000000000 1000000000 1000000000 1000000000 1000000000
",
        @"3000000000
",
        TestName = "{m}-3")]
    public void CTest(string input, string output)
    {
        Utility.InOutTest(Tasks.C.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"4
1 5 4
7 8
6
",
        @"13
",
        TestName = "{m}-1")]
    [TestCase(
        @"3
1 2
3
",
        @"3
",
        TestName = "{m}-2")]
    [TestCase(
        @"16
5 6 5 2 1 7 9 7 2 5 5 2 4 7 6
8 7 7 9 8 1 9 6 10 8 8 6 10 3
10 5 8 1 10 7 8 4 8 6 5 1 10
7 4 1 4 5 4 5 10 1 5 1 2
2 9 9 7 6 2 2 8 3 5 2
9 10 3 1 1 2 10 7 7 5
10 6 1 8 9 3 2 4 2
10 10 8 9 2 10 7 9
5 8 8 7 5 8 2
4 2 2 6 8 3
2 7 3 10 3
5 7 10 3
8 5 7
9 1
4
",
        @"75
",
        TestName = "{m}-3")]
    public void DTest(string input, string output)
    {
        Utility.InOutTest(Tasks.D.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"5
1 2 1 3 2
",
        @"3
",
        TestName = "{m}-1")]
    [TestCase(
        @"7
1 2 3 4 5 6 7
",
        @"0
",
        TestName = "{m}-2")]
    [TestCase(
        @"13
9 7 11 7 3 8 1 13 11 11 11 6 13
",
        @"20
",
        TestName = "{m}-3")]
    public void ETest(string input, string output)
    {
        Utility.InOutTest(Tasks.E.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"3
-6 0 7
3 5 10
",
        @"6
",
        TestName = "{m}-1")]
    [TestCase(
        @"1
0
1000000000000000000
",
        @"2000000000000000001
",
        TestName = "{m}-2")]
    [TestCase(
        @"2
-100 100
1 1
",
        @"0
",
        TestName = "{m}-3")]
    public void FTest(string input, string output)
    {
        Utility.InOutTest(Tasks.F.Solve, input, output);
    }
}
