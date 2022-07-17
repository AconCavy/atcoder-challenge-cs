using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"pop
",
            @"o
")]
        [TestCase(
            @"abc
",
            @"a
")]
        [TestCase(
            @"xxx
",
            @"-1
")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"6 1 0 2
80 60 80 60 70 70
40 20 50 90 90 80
",
            @"1
4
5
")]
        [TestCase(
            @"5 2 1 2
0 100 0 100 0
0 0 100 100 0
",
            @"1
2
3
4
5
")]
        [TestCase(
            @"15 4 3 2
30 65 20 95 100 45 70 85 20 35 95 50 40 15 85
0 25 45 35 65 70 80 90 40 55 20 20 45 75 100
",
            @"2
4
5
6
7
8
11
14
15
")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"2 3 4
",
            @"12
")]
        [TestCase(
            @"1 5 5
",
            @"0
")]
        [TestCase(
            @"10 5 5
",
            @"3942349900
")]
        public void CTest(string input, string output)
        {
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"5 2
3 5 2 1 4
",
            @"4
3
3
-1
4
")]
        [TestCase(
            @"5 1
1 2 3 4 5
",
            @"1
2
3
4
5
")]
        [TestCase(
            @"15 3
3 14 15 9 2 6 5 13 1 7 10 11 8 12 4
",
            @"9
9
9
15
15
6
-1
-1
6
-1
-1
-1
-1
6
15
")]
        public void DTest(string input, string output)
        {
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3 5
1 3
1 4
2 5
",
            @"0 1 3 2 1
")]
        [TestCase(
            @"1 2
1 2
",
            @"2 1
")]
        [TestCase(
            @"5 9
1 5
1 7
5 6
5 8
2 6
",
            @"0 0 1 2 4 4 3 2 1
")]
        public void ETest(string input, string output)
        {
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }

        //         [Timeout(2000)]
        //         [TestCase(
        //             @"2 3 5
        // 1 3
        // 1 4
        // 1 5
        // 2 4
        // 2 5
        // ",
        //             @"1 2 4 5
        // ")]
        //         [TestCase(
        //             @"3 2 4
        // 1 4
        // 1 5
        // 2 5
        // 3 5
        // ",
        //             @"-1
        // ")]
        //         [TestCase(
        //             @"4 5 9
        // 3 5
        // 1 8
        // 3 7
        // 1 9
        // 4 6
        // 2 7
        // 4 8
        // 1 7
        // 2 9
        // ",
        //             @"1 7 2 9
        // ")]
        //         public void FTest(string input, string output)
        //         {
        //             Utility.InOutTest(Tasks.F.Solve, input, output);
        //         }
    }
}
