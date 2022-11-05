using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"abcdaxayz
",
            @"7
")]
        [TestCase(
            @"bcbbbz
",
            @"-1
")]
        [TestCase(
            @"aaaaa
",
            @"5
")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"6 6
3 6
1 3
5 6
2 5
1 2
1 6
",
            @"3 2 3 6
2 1 5
2 1 6
0
2 2 6
3 1 3 5
")]
        [TestCase(
            @"5 10
1 2
1 3
1 4
1 5
2 3
2 4
2 5
3 4
3 5
4 5
",
            @"4 2 3 4 5
4 1 3 4 5
4 1 2 4 5
4 1 2 3 5
4 1 2 3 4
")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3
3 1 2
",
            @"2 3 1
")]
        [TestCase(
            @"10
9 8 6 5 10 3 1 2 4 7
",
            @"9 8 6 5 10 2 7 4 3 1
")]
        public void CTest(string input, string output)
        {
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3
1 4 3
",
            @"3
")]
        [TestCase(
            @"3
2 7 6
",
            @"-1
")]
        [TestCase(
            @"6
1 1 1 1 1 1
",
            @"0
")]
        public void DTest(string input, string output)
        {
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"4 4
....
#.#.
.S..
.##.
",
            @"Yes
")]
        [TestCase(
            @"2 2
S.
.#
",
            @"No
")]
        [TestCase(
            @"5 7
.#...#.
..#.#..
...S...
..#.#..
.#...#.
",
            @"No
")]
        public void ETest(string input, string output)
        {
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3
5 7 5
",
            @"5
499122183
443664163
")]
        [TestCase(
            @"7
22 75 26 45 72 81 47
",
            @"22
249561150
110916092
873463862
279508479
360477194
529680742
")]
        public void FTest(string input, string output)
        {
            Utility.InOutTest(Tasks.F.Solve, input, output);
        }
    }
}
