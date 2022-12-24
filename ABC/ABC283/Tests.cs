using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"4 3
",
            @"64
")]
        [TestCase(
            @"5 5
",
            @"3125
")]
        [TestCase(
            @"8 1
",
            @"8
")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3
1 3 5
7
2 2
2 3
1 3 0
2 3
1 2 8
2 2
2 1
",
            @"3
5
0
8
1
")]
        [TestCase(
            @"5
22 2 16 7 30
10
1 4 0
1 5 0
2 2
2 3
2 4
2 5
1 4 100
1 5 100
2 3
2 4
",
            @"2
16
0
0
16
100
")]
        [TestCase(
            @"7
478 369 466 343 541 42 165
20
2 1
1 7 729
1 6 61
1 6 838
1 3 319
1 4 317
2 4
1 1 673
1 3 176
1 5 250
1 1 468
2 6
1 7 478
1 5 595
2 6
1 6 599
1 6 505
2 3
2 5
2 1
",
            @"478
317
838
838
176
595
468
")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"40004
",
            @"4
")]
        [TestCase(
            @"1355506027
",
            @"10
")]
        [TestCase(
            @"10888869450418352160768000001
",
            @"27
")]
        public void CTest(string input, string output)
        {
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"((a)ba)
",
            @"Yes
")]
        [TestCase(
            @"(a(ba))
",
            @"No
")]
        [TestCase(
            @"(((())))
",
            @"Yes
")]
        [TestCase(
            @"abca
",
            @"No
")]
        public void DTest(string input, string output)
        {
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3 3
1 1 0
1 0 1
1 0 0
",
            @"1
")]
        [TestCase(
            @"4 4
1 0 0 0
0 1 1 1
0 0 1 0
1 1 0 1
",
            @"2
")]
        [TestCase(
            @"2 3
0 1 0
0 1 1
",
            @"-1
")]
        public void ETest(string input, string output)
        {
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"4
3 2 4 1
",
            @"2 2 3 3
")]
        [TestCase(
            @"7
1 2 3 4 5 6 7
",
            @"2 2 2 2 2 2 2
")]
        [TestCase(
            @"16
12 10 7 14 8 3 11 13 2 5 6 16 4 1 15 9
",
            @"3 3 3 5 3 4 3 3 4 2 2 4 4 4 4 7
")]
        public void FTest(string input, string output)
        {
            Utility.InOutTest(Tasks.F.Solve, input, output);
        }
    }
}
