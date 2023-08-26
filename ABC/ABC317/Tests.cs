using NUnit.Framework;

namespace Tests;

public class Tests
{
    [Timeout(2000)]
    [TestCase(
        @"3 100 200
50 200 999
",
        @"2
",
        TestName = "{m}-1")]
    [TestCase(
        @"2 10 21
10 999
",
        @"2
",
        TestName = "{m}-2")]
    [TestCase(
        @"10 500 999
38 420 490 585 613 614 760 926 945 999
",
        @"4
",
        TestName = "{m}-3")]
    public void ATest(string input, string output)
    {
        Utility.InOutTest(Tasks.A.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"3
2 3 5
",
        @"4
",
        TestName = "{m}-1")]
    [TestCase(
        @"8
3 1 4 5 9 2 6 8
",
        @"7
",
        TestName = "{m}-2")]
    [TestCase(
        @"16
152 153 154 147 148 149 158 159 160 155 156 157 144 145 146 150
",
        @"151
",
        TestName = "{m}-3")]
    public void BTest(string input, string output)
    {
        Utility.InOutTest(Tasks.B.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"4 4
1 2 1
2 3 10
1 3 100
1 4 1000
",
        @"1110
",
        TestName = "{m}-1")]
    [TestCase(
        @"10 1
5 9 1
",
        @"1
",
        TestName = "{m}-2")]
    [TestCase(
        @"10 13
1 2 1
1 10 1
2 3 1
3 4 4
4 7 2
4 8 1
5 8 1
5 9 3
6 8 1
6 9 5
7 8 1
7 9 4
9 10 3
",
        @"20
",
        TestName = "{m}-3")]
    public void CTest(string input, string output)
    {
        Utility.InOutTest(Tasks.C.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"1
3 8 1
",
        @"3
",
        TestName = "{m}-1")]
    [TestCase(
        @"2
3 6 2
1 8 5
",
        @"4
",
        TestName = "{m}-2")]
    [TestCase(
        @"3
3 4 2
1 2 3
7 2 6
",
        @"0
",
        TestName = "{m}-3")]
    [TestCase(
        @"10
1878 2089 16
1982 1769 13
2148 1601 14
2189 2362 15
2268 2279 16
2394 2841 18
2926 2971 20
3091 2146 20
3878 4685 38
4504 4617 29
",
        @"86
",
        TestName = "{m}-4")]
    public void DTest(string input, string output)
    {
        Utility.InOutTest(Tasks.D.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"5 7
....Sv.
.>.....
.......
>..<.#<
^G....>
",
        @"15
",
        TestName = "{m}-1")]
    [TestCase(
        @"4 3
S..
.<.
.>.
..G
",
        @"-1
",
        TestName = "{m}-2")]
    public void ETest(string input, string output)
    {
        Utility.InOutTest(Tasks.E.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"13 2 3 5
",
        @"4
",
        TestName = "{m}-1")]
    [TestCase(
        @"1000000000000000000 1 1 1
",
        @"426724011
",
        TestName = "{m}-2")]
    [TestCase(
        @"31415926535897932 3 8 4
",
        @"759934997
",
        TestName = "{m}-3")]
    public void FTest(string input, string output)
    {
        Utility.InOutTest(Tasks.F.Solve, input, output);
    }
}
