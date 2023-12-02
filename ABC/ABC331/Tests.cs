using NUnit.Framework;

namespace Tests;

public class Tests
{
    [Timeout(2000)]
    [TestCase(
        @"12 30
2023 12 30
",
        @"2024 1 1
",
        TestName = "{m}-1")]
    [TestCase(
        @"36 72
6789 23 45
",
        @"6789 23 46
",
        TestName = "{m}-2")]
    [TestCase(
        @"12 30
2012 6 20
",
        @"2012 6 21
",
        TestName = "{m}-3")]
    public void ATest(string input, string output)
    {
        Utility.InOutTest(Tasks.A.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"16 120 150 200
",
        @"300
",
        TestName = "{m}-1")]
    [TestCase(
        @"10 100 50 10
",
        @"10
",
        TestName = "{m}-2")]
    [TestCase(
        @"99 600 800 1200
",
        @"10000
",
        TestName = "{m}-3")]
    public void BTest(string input, string output)
    {
        Utility.InOutTest(Tasks.B.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"5
1 4 1 4 2
",
        @"10 0 10 0 8
",
        TestName = "{m}-1")]
    [TestCase(
        @"10
31 42 59 26 53 58 97 93 23 54
",
        @"456 414 190 487 361 249 0 97 513 307
",
        TestName = "{m}-2")]
    [TestCase(
        @"50
1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1
",
        @"0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0
",
        TestName = "{m}-3")]
    public void CTest(string input, string output)
    {
        Utility.InOutTest(Tasks.C.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"3 2
WWB
BBW
WBW
1 2 3 4
0 3 4 5
",
        @"4
7
",
        TestName = "{m}-1")]
    [TestCase(
        @"10 5
BBBWWWBBBW
WWWWWBBBWB
BBBWBBWBBB
BBBWWBWWWW
WWWWBWBWBW
WBBWBWBBBB
WWBBBWWBWB
WBWBWWBBBB
WBWBWBBWWW
WWWBWWBWWB
5 21 21 93
35 35 70 43
55 72 61 84
36 33 46 95
0 0 999999999 999999999
",
        @"621
167
44
344
500000000000000000
",
        TestName = "{m}-2")]

    public void DTest(string input, string output)
    {
        Utility.InOutTest(Tasks.D.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"2 3 3
2 1
10 30 20
1 2
2 1
2 3
",
        @"31
",
        TestName = "{m}-1")]
    [TestCase(
        @"2 1 0
1000000000 1
1000000000
",
        @"2000000000
",
        TestName = "{m}-2")]
    [TestCase(
        @"10 10 10
47718 21994 74148 76721 98917 73766 29598 59035 69293 29127
7017 46004 16086 62644 74928 57404 32168 45794 19493 71590
1 3
2 6
4 5
5 4
5 5
5 6
5 7
5 8
5 10
7 3
",
        @"149076
",
        TestName = "{m}-3")]
    public void ETest(string input, string output)
    {
        Utility.InOutTest(Tasks.E.Solve, input, output);
    }

    [Timeout(3000)]
    [TestCase(
        @"7 8
abcbacb
2 1 5
2 4 7
2 2 2
1 5 c
2 1 5
2 4 7
1 4 c
2 3 6
",
        @"Yes
No
Yes
No
Yes
Yes
",
        TestName = "{m}-1")]
    public void FTest(string input, string output)
    {
        Utility.InOutTest(Tasks.F.Solve, input, output);
    }
}
