using NUnit.Framework;

namespace Tests;

public class Tests
{
    [Timeout(2000)]
    [TestCase(
        @"6 200
100 675 201 200 199 328
",
        @"499
",
        TestName = "{m}-1")]
    [TestCase(
        @"8 675
675 675 675 675 675 675 675 675
",
        @"5400
",
        TestName = "{m}-2")]
    [TestCase(
        @"8 674
675 675 675 675 675 675 675 675
",
        @"0
",
        TestName = "{m}-3")]
    public void ATest(string input, string output)
    {
        Utility.InOutTest(Tasks.A.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"12
31 29 31 30 31 30 31 31 30 31 30 31
",
        @"13
",
        TestName = "{m}-1")]
    [TestCase(
        @"10
10 1 2 3 4 5 6 7 8 100
",
        @"1
",
        TestName = "{m}-2")]
    [TestCase(
        @"30
73 8 55 26 97 48 37 47 35 55 5 17 62 2 60 23 99 73 34 75 7 46 82 84 29 41 32 31 52 32
",
        @"15
",
        TestName = "{m}-3")]
    public void BTest(string input, string output)
    {
        Utility.InOutTest(Tasks.B.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"11 4
mississippi
3 9
4 10
4 6
7 7
",
        @"2
2
0
0
",
        TestName = "{m}-1")]
    [TestCase(
        @"5 1
aaaaa
1 5
",
        @"4
",
        TestName = "{m}-2")]
    public void CTest(string input, string output)
    {
        Utility.InOutTest(Tasks.C.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"BAABCBCCABCAC
",
        @"BCAC
",
        TestName = "{m}-1")]
    [TestCase(
        @"ABCABC
",
        @"
",
        TestName = "{m}-2")]
    [TestCase(
        @"AAABCABCABCAABCABCBBBAABCBCCCAAABCBCBCC
",
        @"AAABBBCCC
",
        TestName = "{m}-3")]
    public void DTest(string input, string output)
    {
        Utility.InOutTest(Tasks.D.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"5 6 328
1 2 99
1 3 102
2 3 86
2 4 94
2 5 95
3 4 81
",
        @"33
",
        TestName = "{m}-1")]
    [TestCase(
        @"6 5 998244353
1 2 337361568
1 6 450343304
2 3 61477244
2 5 745383438
4 5 727360840
",
        @"325437688
",
        TestName = "{m}-2")]
    [TestCase(
        @"8 28 936294041850197
1 2 473294720906780
1 3 743030800139244
1 4 709363019414774
1 5 383643612490312
1 6 557102781022861
1 7 623179288538138
1 8 739618599410809
2 3 857687812294404
2 4 893923168139714
2 5 581822471860662
2 6 740549363586558
2 7 307226438833222
2 8 447399029952998
3 4 636318083622768
3 5 44548707643622
3 6 307262781240755
3 7 12070267388230
3 8 700247263184082
4 5 560567890325333
4 6 704726113717147
4 7 588263818615687
4 8 549007536393172
5 6 779230871080408
5 7 825982583786498
5 8 713928998174272
6 7 751331074538826
6 8 449873635430228
7 8 11298381761479
",
        @"11360716373
",
        TestName = "{m}-3")]
    public void ETest(string input, string output)
    {
        Utility.InOutTest(Tasks.E.Solve, input, output);
    }

    [Timeout(2000)]
    [TestCase(
        @"3 5
1 2 2
3 2 -3
2 1 -1
3 3 0
1 3 5
",
        @"1 2 4 5
",
        TestName = "{m}-1")]
    [TestCase(
        @"200000 1
1 1 1
",
        @"
",
        TestName = "{m}-2")]
    [TestCase(
        @"5 20
4 2 125421359
2 5 -191096267
3 4 -42422908
3 5 -180492387
3 3 174861038
2 3 -82998451
3 4 -134761089
3 1 -57159320
5 2 191096267
2 4 -120557647
4 2 125421359
2 3 142216401
4 5 -96172984
3 5 -108097816
1 5 -50938496
1 2 140157771
5 4 65674908
4 3 35196193
4 4 0
3 4 188711840
",
        @"1 2 3 6 8 9 11 14 15 16 17 19
",
        TestName = "{m}-3")]
    public void FTest(string input, string output)
    {
        Utility.InOutTest(Tasks.F.Solve, input, output);
    }
}
