using NUnit.Framework;

namespace Tests;

public class Tests
{
    [Timeout(2000)]
    [TestCase(
        @"4
3 2 5 2
",
        @"3
",
        TestName = "{m}-1")]
    [TestCase(
        @"3
4 3 2
",
        @"-1
",
        TestName = "{m}-2")]
    [TestCase(
        @"7
10 5 10 2 10 13 15
",
        @"6
",
        TestName = "{m}-3")]
    public void ATest(string input, string output)
    {
        Utility.InOutTest(Tasks.A.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"7 6
2 5 1 4 1 2 3
",
        @"4
",
        TestName = "{m}-1")]
    [TestCase(
        @"7 10
1 10 1 10 1 10 1
",
        @"7
",
        TestName = "{m}-2")]
    [TestCase(
        @"15 100
73 8 55 26 97 48 37 47 35 55 5 17 62 2 60
",
        @"8
",
        TestName = "{m}-3")]
    public void BTest(string input, string output)
    {
        Utility.InOutTest(Tasks.B.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"3
3 50000001 50000002
",
        @"100000012
",
        TestName = "{m}-1")]
    [TestCase(
        @"5
1 3 99999999 99999994 1000000
",
        @"303999988
",
        TestName = "{m}-2")]
    public void CTest(string input, string output)
    {
        Utility.InOutTest(Tasks.C.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"3
3 14 15
",
        @"2044
",
        TestName = "{m}-1")]
    [TestCase(
        @"5
1001 5 1000000 1000000000 100000
",
        @"625549048
",
        TestName = "{m}-2")]
    public void DTest(string input, string output)
    {
        Utility.InOutTest(Tasks.D.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"3
ab abc arc
",
        @"4
",
        TestName = "{m}-1")]
    [TestCase(
        @"11
ab bb aaa bba baba babb aaaba aabbb a a b
",
        @"32
",
        TestName = "{m}-2")]
    public void ETest(string input, string output)
    {
        Utility.InOutTest(Tasks.E.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"3
7 2
1 6
",
        @"5
",
        TestName = "{m}-1")]
    [TestCase(
        @"1
41 42
13 56
",
        @"42
",
        TestName = "{m}-2")]
    [TestCase(
        @"100
100 99
199 1
",
        @"0
",
        TestName = "{m}-3")]
    [TestCase(
        @"96929423
5105216413055191 10822465733465225
1543712011036057 14412421458305526
",
        @"79154049
",
        TestName = "{m}-4")]
    public void FTest(string input, string output)
    {
        Utility.InOutTest(Tasks.F.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"6 3
4
5 30
2 10
4 25
2 15
",
        @"49
",
        TestName = "{m}-1")]
    [TestCase(
        @"6 1000000000
4
5 30
2 10
4 25
2 15
",
        @"0
",
        TestName = "{m}-2")]
    [TestCase(
        @"50 10
15
37 261
28 404
49 582
19 573
18 633
3 332
31 213
30 377
50 783
17 798
4 561
41 871
15 525
16 444
26 453
",
        @"5000
",
        TestName = "{m}-3")]
    [TestCase(
        @"50 1000000000
15
30 60541209756
48 49238708511
1 73787345006
24 47221018887
9 20218773368
34 40025202486
14 28286410866
24 82115648680
37 62913240066
14 92020110916
24 20965327730
32 67598565422
39 79828753874
40 52778306283
40 67894622518
",
        @"606214471001
",
        TestName = "{m}-4")]
    public void GTest(string input, string output)
    {
        Utility.InOutTest(Tasks.G.Solve, input, output);
    }
}
