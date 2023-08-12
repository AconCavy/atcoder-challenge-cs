using NUnit.Framework;

namespace Tests;

public class Tests
{
    [Timeout(2000)]
    [TestCase(
        @"2
",
        @"3.14
",
        TestName = "{m}-1")]
    [TestCase(
        @"32
",
        @"3.14159265358979323846264338327950
",
        TestName = "{m}-2")]
    [TestCase(
        @"100
",
        @"3.1415926535897932384626433832795028841971693993751058209749445923078164062862089986280348253421170679
",
        TestName = "{m}-3")]
    public void ATest(string input, string output)
    {
        Utility.InOutTest(Tasks.A.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"4
3
7 19 20
4
4 19 24 0
2
26 10
3
19 31 24
19
",
        @"2
1 4
",
        TestName = "{m}-1")]
    [TestCase(
        @"3
1
1
1
2
1
3
0
",
        @"0

",
        TestName = "{m}-2")]
    public void BTest(string input, string output)
    {
        Utility.InOutTest(Tasks.B.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"8 3
apzbqrcs
1 2 3 1 2 2 1 2
",
        @"cszapqbr
",
        TestName = "{m}-1")]
    [TestCase(
        @"2 1
aa
1 1
",
        @"aa
",
        TestName = "{m}-2")]
    public void CTest(string input, string output)
    {
        Utility.InOutTest(Tasks.C.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"7
AtCoder
5
1 4 i
3 0 a
1 5 b
2 0 a
1 4 Y
",
        @"atcYber
",
        TestName = "{m}-1")]
    [TestCase(
        @"35
TheQuickBrownFoxJumpsOverTheLazyDog
10
2 0 a
1 19 G
1 13 m
1 2 E
1 21 F
2 0 a
1 27 b
3 0 a
3 0 a
1 15 i
",
        @"TEEQUICKBROWMFiXJUGPFOVERTBELAZYDOG
",
        TestName = "{m}-2")]
    public void DTest(string input, string output)
    {
        Utility.InOutTest(Tasks.D.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"3 14
100 2 5 9
50 4 1 2 4 8
70 5 2 4 2 8 8
",
        @"215.913355350494384765625
",
        TestName = "{m}-1")]
    [TestCase(
        @"2 100
1 2 1 2
10 6 0 0 0 0 0 100
",
        @"60
",
        TestName = "{m}-2")]
    [TestCase(
        @"20 90
3252 9 0 4 2 7 3 2 3 2 4
2147 1 1
4033 8 0 4 1 7 5 2 5 0
3795 6 6 6 2 3 2 2
3941 7 2 4 4 7 2 0 5
2815 6 2 1 0 5 2 2
3020 2 3 6
3858 9 4 2 7 3 0 4 4 6 5
4533 10 3 6 4 0 6 4 4 2 7 7
4198 8 6 7 0 6 3 6 5 6
3739 8 2 7 1 5 1 4 4 7
2465 4 1 4 0 1
4418 9 7 6 2 4 6 1 5 0 7
5450 12 0 4 4 7 7 4 4 5 4 5 3 7
4196 9 1 6 5 5 7 2 3 6 3
4776 9 2 2 7 3 6 6 1 6 6
2286 3 3 5 6
3152 3 4 1 5
3509 7 0 6 7 0 1 0 3
2913 6 0 1 5 0 5 6
",
        @"45037.072314895291126319493887599716
",
        TestName = "{m}-3")]
    public void ETest(string input, string output)
    {
        Utility.InOutTest(Tasks.E.Solve, input, output, 1e-5);
    }
}
