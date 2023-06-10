using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"53
",
            @"55
",
            TestName = "{m}-1")]
        [TestCase(
            @"21
",
            @"20
",
            TestName = "{m}-2")]
        [TestCase(
            @"100
",
            @"100
",
            TestName = "{m}-3")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"A C
",
            @"4
",
            TestName = "{m}-1")]
        [TestCase(
            @"G B
",
            @"20
",
            TestName = "{m}-2")]
        [TestCase(
            @"C F
",
            @"10
",
            TestName = "{m}-3")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"5 6
......
..#.#.
..###.
..###.
......
",
            @"2 4
",
            TestName = "{m}-1")]
        [TestCase(
            @"3 2
#.
##
##
",
            @"1 2
",
            TestName = "{m}-2")]
        [TestCase(
            @"6 6
..####
..##.#
..####
..####
..####
......
",
            @"2 5
",
            TestName = "{m}-3")]
        public void CTest(string input, string output)
        {
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"7
0 240 720 1320 1440 1800 2160
3
480 1920
720 1200
0 2160
",
            @"480
0
960
",
            TestName = "{m}-1")]
        [TestCase(
            @"21
0 20 62 192 284 310 323 324 352 374 409 452 486 512 523 594 677 814 838 946 1000
10
77 721
255 541
478 970
369 466
343 541
42 165
16 618
222 592
730 983
338 747
",
            @"296
150
150
49
89
20
279
183
61
177
",
            TestName = "{m}-2")]
        public void DTest(string input, string output)
        {
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"5 5 2
1 2
2 3
2 4
3 5
1 5
1 1
5 2
",
            @"4
1 2 3 5
",
            TestName = "{m}-1")]
        [TestCase(
            @"3 0 1
2 3
",
            @"1
2
",
            TestName = "{m}-2")]
        [TestCase(
            @"10 10 2
2 1
5 1
6 1
2 4
2 5
2 10
8 5
8 6
9 6
7 9
3 4
8 2
",
            @"7
1 2 3 5 6 8 9
",
            TestName = "{m}-3")]
        public void ETest(string input, string output)
        {
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }
    }
}
