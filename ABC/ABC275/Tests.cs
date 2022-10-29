using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"3
50 80 70
",
            @"2
")]
        [TestCase(
            @"1
1000000000
",
            @"1
")]
        [TestCase(
            @"10
22 75 26 45 72 81 47 29 97 2
",
            @"9
")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"2 3 5 1 2 4
",
            @"22
")]
        [TestCase(
            @"1 1 1000000000 0 0 0
",
            @"1755647
")]
        [TestCase(
            @"1000000000000000000 1000000000000000000 1000000000000000000 1000000000000000000 1000000000000000000 1000000000000000000
",
            @"0
")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"##.......
##.......
.........
.......#.
.....#...
........#
......#..
.........
.........
",
            @"2
")]
        [TestCase(
            @".#.......
#.#......
.#.......
.........
....#.#.#
.........
....#.#.#
........#
.........
",
            @"3
")]
        public void CTest(string input, string output)
        {
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"2
",
            @"3
")]
        [TestCase(
            @"0
",
            @"1
")]
        [TestCase(
            @"100
",
            @"55
")]
        public void DTest(string input, string output)
        {
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"2 2 1
",
            @"499122177
")]
        [TestCase(
            @"10 5 6
",
            @"184124175
")]
        [TestCase(
            @"100 1 99
",
            @"0
")]
        public void ETest(string input, string output)
        {
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"4 5
1 2 3 4
",
            @"1
2
1
1
1
")]
        [TestCase(
            @"1 5
3
",
            @"-1
-1
0
-1
-1
")]
        [TestCase(
            @"12 20
2 5 6 5 2 1 7 9 7 2 5 5
",
            @"2
1
2
2
1
2
1
2
2
1
2
1
1
1
2
2
1
1
1
1
")]
        public void FTest(string input, string output)
        {
            Utility.InOutTest(Tasks.F.Solve, input, output);
        }
    }
}
