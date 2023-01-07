using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"3
Takahashi
Aoki
Snuke
",
            @"Snuke
Aoki
Takahashi
")]
        [TestCase(
            @"4
2023
Year
New
Happy
",
            @"Happy
New
Year
2023
")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"4
3
1 2 3
2
20 23
10
6 10 4 1 5 9 8 6 5 1
1
1000000000
",
            @"2
1
5
0
")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"5 3
1 2
1 3
4 5
",
            @"2
")]
        [TestCase(
            @"5 0
",
            @"5
")]
        [TestCase(
            @"4 6
1 2
1 3
1 4
2 3
2 4
3 4
",
            @"1
")]
        public void CTest(string input, string output)
        {
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [Timeout(3000)]
        [TestCase(
            @"3
2023
63
1059872604593911
",
            @"17 7
3 7
104149 97711
")]
        public void DTest(string input, string output)
        {
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"4 2
1 2
2 3
",
            @"3
")]
        [TestCase(
            @"4 6
1 2
1 3
1 4
2 3
2 4
3 4
",
            @"16
")]
        [TestCase(
            @"8 21
2 6
1 3
5 6
3 8
3 6
4 7
4 6
3 4
1 5
2 4
1 2
2 7
1 4
3 5
2 5
2 3
4 5
3 7
6 7
5 7
2 8
",
            @"2023
")]
        public void ETest(string input, string output)
        {
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3
abcbac
",
            @"abc
2
")]
        [TestCase(
            @"4
abababab
",
            @"abab
1
")]
        [TestCase(
            @"3
agccga
",
            @"cga
0
")]
        [TestCase(
            @"4
atcodeer
",
            @"-1
")]
        public void FTest(string input, string output)
        {
            Utility.InOutTest(Tasks.F.Solve, input, output);
        }
    }
}
