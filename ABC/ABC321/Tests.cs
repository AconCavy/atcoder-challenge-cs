using NUnit.Framework;

namespace Tests;

public class Tests
{
    [Timeout(2000)]
    [TestCase(
        @"321
",
        @"Yes
",
        TestName = "{m}-1")]
    [TestCase(
        @"123
",
        @"No
",
        TestName = "{m}-2")]
    [TestCase(
        @"1
",
        @"Yes
",
        TestName = "{m}-3")]
    [TestCase(
        @"86411
",
        @"No
",
        TestName = "{m}-4")]
    public void ATest(string input, string output)
    {
        Utility.InOutTest(Tasks.A.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"5 180
40 60 80 50
",
        @"70
",
        TestName = "{m}-1")]
    [TestCase(
        @"3 100
100 100
",
        @"0
",
        TestName = "{m}-2")]
    [TestCase(
        @"5 200
0 0 99 99
",
        @"-1
",
        TestName = "{m}-3")]
    [TestCase(
        @"10 480
59 98 88 54 70 24 8 94 46
",
        @"45
",
        TestName = "{m}-4")]
    public void BTest(string input, string output)
    {
        Utility.InOutTest(Tasks.B.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"15
",
        @"32
",
        TestName = "{m}-1")]
    [TestCase(
        @"321
",
        @"9610
",
        TestName = "{m}-2")]
    [TestCase(
        @"777
",
        @"983210
",
        TestName = "{m}-3")]
    public void CTest(string input, string output)
    {
        Utility.InOutTest(Tasks.C.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"2 2 7
3 5
6 1
",
        @"24
",
        TestName = "{m}-1")]
    [TestCase(
        @"1 3 2
1
1 1 1
",
        @"6
",
        TestName = "{m}-2")]
    [TestCase(
        @"7 12 25514963
2436426 24979445 61648772 23690081 33933447 76190629 62703497
11047202 71407775 28894325 31963982 22804784 50968417 30302156 82631932 61735902 80895728 23078537 7723857
",
        @"2115597124
",
        TestName = "{m}-3")]
    public void DTest(string input, string output)
    {
        Utility.InOutTest(Tasks.D.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"5
10 2 0
10 2 1
10 2 2
10 2 3
10 2 4
",
        @"1
3
4
2
0
",
        TestName = "{m}-1")]
    [TestCase(
        @"10
822981260158260522 52 20
760713016476190629 2314654 57
1312150450968417 1132551176249851 7
1000000000000000000 1083770654 79
234122432773361868 170290518806790 23
536187734191890310 61862 14
594688604155374934 53288633578 39
1000000000000000000 120160810 78
89013034180999835 14853481725739 94
463213054346948152 825589 73
",
        @"1556480
140703128616960
8
17732923532771328
65536
24576
2147483640
33776997205278720
7881299347898368
27021597764222976
",
        TestName = "{m}-2")]
    public void ETest(string input, string output)
    {
        Utility.InOutTest(Tasks.E.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"15 10
+ 5
+ 2
+ 3
- 2
+ 5
+ 10
- 3
+ 1
+ 3
+ 3
- 5
+ 1
+ 7
+ 4
- 3
",
        @"0
0
1
0
1
2
2
2
2
2
1
3
5
8
5
",
        TestName = "{m}-1")]
    public void FTest(string input, string output)
    {
        Utility.InOutTest(Tasks.F.Solve, input, output);
    }
}
