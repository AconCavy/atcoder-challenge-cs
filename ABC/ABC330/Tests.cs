using NUnit.Framework;

namespace Tests;

public class Tests
{
    [Timeout(2000)]
    [TestCase(
        @"5 60
60 20 100 90 40
",
        @"3
",
        TestName = "{m}-1")]
    [TestCase(
        @"4 80
79 78 77 76
",
        @"0
",
        TestName = "{m}-2")]
    [TestCase(
        @"10 50
31 41 59 26 53 58 97 93 23 84
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
        @"5 4 7
3 1 4 9 7
",
        @"4 4 4 7 7
",
        TestName = "{m}-1")]
    [TestCase(
        @"3 10 10
11 10 9
",
        @"10 10 10
",
        TestName = "{m}-2")]
    public void BTest(string input, string output)
    {
        Utility.InOutTest(Tasks.B.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"21
",
        @"1
",
        TestName = "{m}-1")]
    [TestCase(
        @"998244353
",
        @"0
",
        TestName = "{m}-2")]
    [TestCase(
        @"264428617
",
        @"32
",
        TestName = "{m}-3")]
    public void CTest(string input, string output)
    {
        Utility.InOutTest(Tasks.C.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"3
ooo
oxx
xxo
",
        @"4
",
        TestName = "{m}-1")]
    [TestCase(
        @"4
oxxx
xoxx
xxox
xxxo
",
        @"0
",
        TestName = "{m}-2")]
    [TestCase(
        @"15
xooxxooooxxxoox
oxxoxoxxxoxoxxo
oxxoxoxxxoxoxxx
ooooxooooxxoxxx
oxxoxoxxxoxoxxx
oxxoxoxxxoxoxxo
oxxoxooooxxxoox
xxxxxxxxxxxxxxx
xooxxxooxxxooox
oxxoxoxxoxoxxxo
xxxoxxxxoxoxxoo
xooxxxooxxoxoxo
xxxoxxxxoxooxxo
oxxoxoxxoxoxxxo
xooxxxooxxxooox
",
        @"2960
",
        TestName = "{m}-3")]
    public void DTest(string input, string output)
    {
        Utility.InOutTest(Tasks.D.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"8 5
2 0 2 2 1 1 2 5
4 3
4 4
6 3
8 1000000000
2 1
",
        @"4
3
6
5
0
",
        TestName = "{m}-1")]
    public void ETest(string input, string output)
    {
        Utility.InOutTest(Tasks.E.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"6 5
2 0
5 2
0 3
3 2
3 4
1 5
",
        @"3
",
        TestName = "{m}-1")]
    [TestCase(
        @"4 400000000000000
1000000000 1000000000
1000000000 1000000000
1000000000 1000000000
1000000000 1000000000
",
        @"0
",
        TestName = "{m}-2")]
    [TestCase(
        @"10 998244353
489733278 189351894
861289363 30208889
450668761 133103889
306319121 739571083
409648209 922270934
930832199 304946211
358683490 923133355
369972904 539399938
915030547 735320146
386219602 277971612
",
        @"484373824
",
        TestName = "{m}-3")]
    public void FTest(string input, string output)
    {
        Utility.InOutTest(Tasks.F.Solve, input, output);
    }
}
