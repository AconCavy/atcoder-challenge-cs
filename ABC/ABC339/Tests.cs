using NUnit.Framework;

namespace Tests;

public class Tests
{
    [Timeout(2000)]
    [TestCase(
        @"atcoder.jp
",
        @"jp
",
        TestName = "{m}-1")]
    [TestCase(
        @"translate.google.com
",
        @"com
",
        TestName = "{m}-2")]
    [TestCase(
        @".z
",
        @"z
",
        TestName = "{m}-3")]
    [TestCase(
        @"..........txt
",
        @"txt
",
        TestName = "{m}-4")]
    public void ATest(string input, string output)
    {
        Utility.InOutTest(Tasks.A.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"3 4 5
",
        @".#..
##..
....
",
        TestName = "{m}-1")]
    [TestCase(
        @"2 2 1000
",
        @"..
..
",
        TestName = "{m}-2")]
    [TestCase(
        @"10 10 10
",
        @"##........
##........
..........
..........
..........
..........
..........
..........
..........
#........#
",
        TestName = "{m}-3")]
    public void BTest(string input, string output)
    {
        Utility.InOutTest(Tasks.B.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"4
3 -5 7 -4
",
        @"3
",
        TestName = "{m}-1")]
    [TestCase(
        @"5
0 0 0 0 0
",
        @"0
",
        TestName = "{m}-2")]
    [TestCase(
        @"4
-1 1000000000 1000000000 1000000000
",
        @"3000000000
",
        TestName = "{m}-3")]
    public void CTest(string input, string output)
    {
        Utility.InOutTest(Tasks.C.Solve, input, output);
    }

    [Timeout(4000)]
    [TestCase(
        @"5
....#
#..#.
.P...
..P..
....#
",
        @"3
",
        TestName = "{m}-1")]
    [TestCase(
        @"2
P#
#P
",
        @"-1
",
        TestName = "{m}-2")]
    [TestCase(
        @"10
..........
..........
..........
..........
....P.....
.....P....
..........
..........
..........
..........
",
        @"10
",
        TestName = "{m}-3")]
    public void DTest(string input, string output)
    {
        Utility.InOutTest(Tasks.D.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"4 2
3 5 1 2
",
        @"3
",
        TestName = "{m}-1")]
    [TestCase(
        @"5 10
10 20 100 110 120
",
        @"3
",
        TestName = "{m}-2")]
    [TestCase(
        @"11 7
21 10 3 19 28 12 11 3 3 15 16
",
        @"6
",
        TestName = "{m}-3")]
    public void ETest(string input, string output)
    {
        Utility.InOutTest(Tasks.E.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"5
2
3
6
12
24
",
        @"6
",
        TestName = "{m}-1")]
    [TestCase(
        @"11
1
2
3
4
5
6
123456789123456789
123456789123456789
987654321987654321
987654321987654321
121932631356500531347203169112635269
",
        @"40
",
        TestName = "{m}-2")]
    [TestCase(
        @"9
4
4
4
2
2
2
1
1
1
",
        @"162
",
        TestName = "{m}-3")]
    public void FTest(string input, string output)
    {
        Utility.InOutTest(Tasks.F.Solve, input, output);
    }
}
