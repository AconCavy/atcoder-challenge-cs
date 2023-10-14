using NUnit.Framework;

namespace Tests;

public class Tests
{
    [Timeout(2000)]
    [TestCase(
        @"3
3 2 4
",
        @"No
",
        TestName = "{m}-1")]
    [TestCase(
        @"4
3 3 3 3
",
        @"Yes
",
        TestName = "{m}-2")]
    [TestCase(
        @"10
73 8 55 26 97 48 37 47 35 55
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
        @"324
",
        @"Yes
",
        TestName = "{m}-1")]
    [TestCase(
        @"5
",
        @"No
",
        TestName = "{m}-2")]
    [TestCase(
        @"32
",
        @"Yes
",
        TestName = "{m}-3")]
    [TestCase(
        @"37748736
",
        @"Yes
",
        TestName = "{m}-4")]
    public void BTest(string input, string output)
    {
        Utility.InOutTest(Tasks.B.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"5 ababc
ababc
babc
abacbc
abdbc
abbac
",
        @"4
1 2 3 4
",
        TestName = "{m}-1")]
    [TestCase(
        @"1 aoki
takahashi
",
        @"0

",
        TestName = "{m}-2")]
    [TestCase(
        @"9 atcoder
atoder
atcode
athqcoder
atcoder
tacoder
jttcoder
atoder
atceoder
atcoer
",
        @"6
1 2 4 7 8 9
",
        TestName = "{m}-3")]
    public void CTest(string input, string output)
    {
        Utility.InOutTest(Tasks.C.Solve, input, output);
    }

    [Timeout(4000)]
    [TestCase(
        @"4
4320
",
        @"2
",
        TestName = "{m}-1")]
    [TestCase(
        @"3
010
",
        @"2
",
        TestName = "{m}-2")]
    [TestCase(
        @"13
8694027811503
",
        @"840
",
        TestName = "{m}-3")]
    public void DTest(string input, string output)
    {
        Utility.InOutTest(Tasks.D.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"3 bac
abba
bcb
aaca
",
        @"3
",
        TestName = "{m}-1")]
    [TestCase(
        @"5 xx
x
x
x
x
x
",
        @"25
",
        TestName = "{m}-2")]
    [TestCase(
        @"1 y
x
",
        @"0
",
        TestName = "{m}-3")]
    [TestCase(
        @"10 ms
mkgn
m
hlms
vmsle
mxsm
nnzdhi
umsavxlb
ffnsybomr
yvmm
naouel
",
        @"68
",
        TestName = "{m}-4")]
    public void ETest(string input, string output)
    {
        Utility.InOutTest(Tasks.E.Solve, input, output);
    }

    [Timeout(5000)]
    [TestCase(
        @"5 7
1 2 3 6
1 3 9 5
2 3 1 5
2 4 5 3
2 5 1 9
3 4 4 8
4 5 2 7
",
        @"0.7500000000000000
",
        TestName = "{m}-1")]
    [TestCase(
        @"3 3
1 3 1 1
1 3 2 1
1 3 3 1
",
        @"3.0000000000000000
",
        TestName = "{m}-2")]
    [TestCase(
        @"10 20
3 4 1 2
7 9 4 5
2 4 4 5
4 5 1 4
6 9 4 1
9 10 3 2
6 10 5 5
5 6 1 2
5 6 5 2
2 3 2 3
6 10 4 4
4 6 3 4
4 8 4 1
3 5 3 2
2 4 3 2
3 5 4 2
1 5 3 4
1 2 4 2
3 7 2 2
7 8 1 3
",
        @"1.8333333333333333
",
        TestName = "{m}-3")]
    public void FTest(string input, string output)
    {
        Utility.InOutTest(Tasks.F.Solve, input, output, 1e-9);
    }
}
