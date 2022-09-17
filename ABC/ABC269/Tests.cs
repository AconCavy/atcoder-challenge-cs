using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"1 2 5 3
",
            @"6
Takahashi
")]
        [TestCase(
            @"10 -20 30 -40
",
            @"-700
Takahashi
")]
        [TestCase(
            @"100 100 100 -100
",
            @"40000
Takahashi
")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"..........
..........
..........
..........
...######.
...######.
...######.
...######.
..........
..........
",
            @"5 8
4 9
")]
        [TestCase(
            @"..........
..#.......
..........
..........
..........
..........
..........
..........
..........
..........
",
            @"2 2
3 3
")]
        [TestCase(
            @"##########
##########
##########
##########
##########
##########
##########
##########
##########
##########
",
            @"1 10
1 10
")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"11
",
            @"0
1
2
3
8
9
10
11
")]
        [TestCase(
            @"0
",
            @"0
")]
        [TestCase(
            @"576461302059761664
",
            @"0
524288
549755813888
549756338176
576460752303423488
576460752303947776
576461302059237376
576461302059761664
")]
        public void CTest(string input, string output)
        {
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"6
-1 -1
0 1
0 2
1 0
1 2
2 0
",
            @"3
")]
        [TestCase(
            @"4
5 0
4 1
-3 -4
-2 -5
",
            @"4
")]
        [TestCase(
            @"5
2 1
2 -1
1 0
3 1
1 -1
",
            @"1
")]
        public void DTest(string input, string output)
        {
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"5 4
6
1 3 2 4
1 5 1 1
5 5 1 4
4 4 2 2
5 5 4 4
1 5 1 4
",
            @"28
27
36
14
0
104
")]
        [TestCase(
            @"1000000000 1000000000
3
1000000000 1000000000 1000000000 1000000000
165997482 306594988 719483261 992306147
1 1000000000 1 1000000000
",
            @"716070898
240994972
536839100
")]
        [TestCase(
            @"999999999 999999999
3
999999999 999999999 999999999 999999999
216499784 840031647 84657913 415448790
1 999999999 1 999999999
",
            @"712559605
648737448
540261130
")]
        public void FTest(string input, string output)
        {
            Utility.InOutTest(Tasks.F.Solve, input, output);
        }
    }
}
