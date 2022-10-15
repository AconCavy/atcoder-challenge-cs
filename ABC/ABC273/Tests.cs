using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"2
",
            @"2
")]
        [TestCase(
            @"3
",
            @"6
")]
        [TestCase(
            @"0
",
            @"1
")]
        [TestCase(
            @"10
",
            @"3628800
")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"2048 2
",
            @"2100
")]
        [TestCase(
            @"1 15
",
            @"0
")]
        [TestCase(
            @"999 3
",
            @"1000
")]
        [TestCase(
            @"314159265358979 12
",
            @"314000000000000
")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"6
2 7 1 8 2 8
",
            @"2
1
2
1
0
0
")]
        [TestCase(
            @"1
1
",
            @"1
")]
        [TestCase(
            @"10
979861204 57882493 979861204 447672230 644706927 710511029 763027379 710511029 447672230 136397527
",
            @"2
1
2
1
2
1
1
0
0
0
")]
        public void CTest(string input, string output)
        {
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"5 5 4 4
3
5 3
2 2
1 4
4
L 2
U 3
L 2
R 4
",
            @"4 2
3 2
3 1
3 5
")]
        [TestCase(
            @"6 6 6 3
7
3 1
4 3
2 6
3 4
5 5
1 1
3 2
10
D 3
U 3
L 2
D 2
U 3
D 3
U 3
R 3
L 3
D 1
",
            @"6 3
5 3
5 1
6 1
4 1
6 1
4 1
4 2
4 1
5 1
")]
        public void DTest(string input, string output)
        {
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }
    }
}
