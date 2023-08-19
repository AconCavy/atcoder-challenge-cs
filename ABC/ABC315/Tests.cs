using NUnit.Framework;

namespace Tests;

public class Tests
{
    [Timeout(2000)]
    [TestCase(
        @"atcoder
",
        @"tcdr
",
        TestName = "{m}-1")]
    [TestCase(
        @"xyz
",
        @"xyz
",
        TestName = "{m}-2")]
    [TestCase(
        @"aaaabbbbcccc
",
        @"bbbbcccc
",
        TestName = "{m}-3")]
    public void ATest(string input, string output)
    {
        Utility.InOutTest(Tasks.A.Solve, input, output, 1e-9);
    }

    [Timeout(2000)]
    [TestCase(
        @"12
31 28 31 30 31 30 31 31 30 31 30 31
",
        @"7 2
",
        TestName = "{m}-1")]
    [TestCase(
        @"1
1
",
        @"1 1
",
        TestName = "{m}-2")]
    [TestCase(
        @"6
3 1 4 1 5 9
",
        @"5 3
",
        TestName = "{m}-3")]
    public void BTest(string input, string output)
    {
        Utility.InOutTest(Tasks.B.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"4
1 4
2 10
2 8
3 6
",
        @"16
",
        TestName = "{m}-1")]
    [TestCase(
        @"4
4 10
3 2
2 4
4 12
",
        @"17
",
        TestName = "{m}-2")]
    public void CTest(string input, string output)
    {
        Utility.InOutTest(Tasks.C.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"4 3
aaa
aaa
abc
abd
",
        @"2
",
        TestName = "{m}-1")]
    [TestCase(
        @"2 5
aaaaa
abcde
",
        @"4
",
        TestName = "{m}-2")]
    [TestCase(
        @"3 3
ooo
ooo
ooo
",
        @"0
",
        TestName = "{m}-3")]
    public void DTest(string input, string output)
    {
        Utility.InOutTest(Tasks.D.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"6
3 2 3 4
2 3 5
0
1 5
0
0
",
        @"3 5 2 4
",
        TestName = "{m}-1")]
    [TestCase(
        @"6
1 2
1 3
1 4
1 5
1 6
0
",
        @"6 5 4 3 2
",
        TestName = "{m}-2")]
    [TestCase(
        @"8
1 5
1 6
1 7
1 8
0
0
0
0
",
        @"5
",
        TestName = "{m}-3")]
    public void ETest(string input, string output)
    {
        Utility.InOutTest(Tasks.E.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"6
0 0
1 1
2 0
0 1
1 0
2 1
",
        @"5.82842712474619009753
",
        TestName = "{m}-1")]
    [TestCase(
        @"10
1 8
3 7
9 4
4 9
6 1
7 5
0 0
1 3
6 8
6 4
",
        @"24.63441361516795872523
",
        TestName = "{m}-2")]
    [TestCase(
        @"10
34 24
47 60
30 31
12 97
87 93
64 46
82 50
14 7
17 24
3 78
",
        @"110.61238353245736230207
",
        TestName = "{m}-3")]
    public void FTest(string input, string output)
    {
        Utility.InOutTest(Tasks.F.Solve, input, output, 1e-5);
    }
}
