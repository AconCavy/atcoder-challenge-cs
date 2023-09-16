using NUnit.Framework;

namespace Tests;

public class Tests
{
    [Timeout(2000)]
    [TestCase(
        @"2 8
",
        @"320
",
        TestName = "{m}-1")]
    [TestCase(
        @"9 9
",
        @"774840978
",
        TestName = "{m}-2")]
    [TestCase(
        @"5 6
",
        @"23401
",
        TestName = "{m}-3")]
    public void ATest(string input, string output)
    {
        Utility.InOutTest(Tasks.A.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"TOYOTA
",
        @"5
",
        TestName = "{m}-1")]
    [TestCase(
        @"ABCDEFG
",
        @"1
",
        TestName = "{m}-2")]
    [TestCase(
        @"AAAAAAAAAA
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
        @"10
1937458062
8124690357
2385760149
",
        @"6
",
        TestName = "{m}-1")]
    [TestCase(
        @"20
01234567890123456789
01234567890123456789
01234567890123456789
",
        @"20
",
        TestName = "{m}-2")]
    [TestCase(
        @"5
11111
22222
33333
",
        @"-1
",
        TestName = "{m}-3")]
    public void CTest(string input, string output)
    {
        Utility.InOutTest(Tasks.C.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"3 2
1 2 2 1
1 3 -1 -2
",
        @"0 0
2 1
-1 -2
",
        TestName = "{m}-1")]
    [TestCase(
        @"3 2
2 1 -2 -1
2 3 -3 -3
",
        @"0 0
2 1
-1 -2
",
        TestName = "{m}-2")]
    [TestCase(
        @"5 7
1 2 0 0
1 2 0 0
2 3 0 0
3 1 0 0
2 1 0 0
3 2 0 0
4 5 0 0
",
        @"0 0
0 0
0 0
undecidable
undecidable
",
        TestName = "{m}-3")]
    public void DTest(string input, string output)
    {
        Utility.InOutTest(Tasks.D.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"3 5
1 1 3
2 10 100
4 100 10000
10 1000 1000000000
100 1000000000 1
",
        @"101
10
1000
",
        TestName = "{m}-1")]
    [TestCase(
        @"3 1
1 1 1
",
        @"1
0
0
",
        TestName = "{m}-2")]
    [TestCase(
        @"1 8
1 1 1
2 2 2
3 3 3
4 4 4
5 5 5
6 6 6
7 7 7
8 8 8
",
        @"15
",
        TestName = "{m}-3")]
    public void ETest(string input, string output)
    {
        Utility.InOutTest(Tasks.E.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"4 10
2 5 9 11
8 10
5 8
4 9
",
        @"9
",
        TestName = "{m}-1")]
    [TestCase(
        @"1 1
100000
",
        @"-1
",
        TestName = "{m}-2")]
    [TestCase(
        @"5 20
4 13 16 18 23
1 16
2 8
4 11
8 13
",
        @"13
",
        TestName = "{m}-3")]
    public void FTest(string input, string output)
    {
        Utility.InOutTest(Tasks.F.Solve, input, output);
    }
}
