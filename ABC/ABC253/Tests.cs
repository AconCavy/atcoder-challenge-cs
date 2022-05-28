using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"5 3 2
",
            @"Yes
")]
        [TestCase(
            @"2 5 3
",
            @"No
")]
        [TestCase(
            @"100 100 100
",
            @"Yes
")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"2 3
--o
o--
",
            @"3
")]
        [TestCase(
            @"5 4
-o--
----
----
----
-o--
",
            @"4
")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"8
1 3
1 2
3
1 2
1 7
3
2 2 3
3
",
            @"1
5
4
")]
        [TestCase(
            @"4
1 10000
1 1000
2 100 3
1 10
",
            @"
")]
        public void CTest(string input, string output)
        {
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"10 3 5
",
            @"22
")]
        [TestCase(
            @"1000000000 314 159
",
            @"495273003954006262
")]
        public void DTest(string input, string output)
        {
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"2 3 1
",
            @"6
")]
        [TestCase(
            @"3 3 2
",
            @"2
")]
        [TestCase(
            @"100 1000 500
",
            @"657064711
")]
        public void ETest(string input, string output)
        {
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }

        //         [Timeout(2000)]
        //         [TestCase(
        //             @"3 3 9
        // 1 1 2 1
        // 3 2 2
        // 2 3 2
        // 3 3 3
        // 3 3 1
        // 1 2 3 3
        // 3 3 2
        // 3 2 3
        // 3 1 2
        // ",
        //             @"1
        // 2
        // 2
        // 5
        // 3
        // 4
        // ")]
        //         [TestCase(
        //             @"1 1 10
        // 1 1 1 1000000000
        // 1 1 1 1000000000
        // 1 1 1 1000000000
        // 1 1 1 1000000000
        // 1 1 1 1000000000
        // 1 1 1 1000000000
        // 1 1 1 1000000000
        // 1 1 1 1000000000
        // 1 1 1 1000000000
        // 3 1 1
        // ",
        //             @"9000000000
        // ")]
        //         [TestCase(
        //             @"10 10 10
        // 1 1 8 5
        // 2 2 6
        // 3 2 1
        // 3 4 7
        // 1 5 9 7
        // 3 3 2
        // 3 2 8
        // 2 8 10
        // 3 8 8
        // 3 1 10
        // ",
        //             @"6
        // 5
        // 5
        // 13
        // 10
        // 0
        // ")]
        //         public void FTest(string input, string output)
        //         {
        //             Utility.InOutTest(Tasks.F.Solve, input, output);
        //         }
    }
}
