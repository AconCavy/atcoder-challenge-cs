using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"38 20 17 168 3
",
            @"168
")]
        [TestCase(
            @"1 0 1 3 2
",
            @"1
")]
        [TestCase(
            @"100 10 100 180 1
",
            @"90
")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"2 2 180
",
            @"-2 -2
")]
        [TestCase(
            @"5 0 120
",
            @"-2.49999999999999911182 4.33012701892219364908
")]
        [TestCase(
            @"0 0 11
",
            @"0.00000000000000000000 0.00000000000000000000
")]
        [TestCase(
            @"15 5 360
",
            @"15.00000000000000177636 4.99999999999999555911
")]
        [TestCase(
            @"-505 191 278
",
            @"118.85878514480690171240 526.66743699786547949770
")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output, 1e-6);
        }

        [Timeout(2000)]
        [TestCase(
            @"abbaac
abbbbaaac
",
            @"Yes
")]
        [TestCase(
            @"xyzz
xyyzz
",
            @"No
")]
        public void CTest(string input, string output)
        {
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"4
0 -2 3 3
0 0 2
2 0 2
2 3 1
-3 3 3
",
            @"Yes
")]
        [TestCase(
            @"3
0 1 0 3
0 0 1
0 0 2
0 0 3
",
            @"No
")]
        public void DTest(string input, string output)
        {
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"4
1
7 2
2
2 2
5 1
1
5 1
2
2 1
7 1
",
            @"3
")]
        [TestCase(
            @"1
1
998244353 1000000000
",
            @"1
")]
        public void ETest(string input, string output)
        {
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"7
1 2 1 0 2 1 1
1 2 8
2 3 9
2 4 10
2 5 -3
5 6 8
5 7 3
",
            @"28
")]
        [TestCase(
            @"20
0 2 0 1 2 1 0 0 3 0 1 1 1 1 0 0 3 0 1 2
4 9 583
4 6 -431
5 9 325
17 6 131
17 2 -520
2 16 696
5 7 662
17 15 845
7 8 307
13 7 849
9 19 242
20 6 909
7 11 -775
17 18 557
14 20 95
18 10 646
4 3 -168
1 3 -917
11 12 30
",
            @"2184
")]
        public void FTest(string input, string output)
        {
            Utility.InOutTest(Tasks.F.Solve, input, output);
        }
    }
}
