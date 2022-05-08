using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"3 4
2 2
",
            @"4
")]
        [TestCase(
            @"3 4
1 3
",
            @"3
")]
        [TestCase(
            @"3 4
3 4
",
            @"2
")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"4 3 2
",
            @"..##..##
..##..##
..##..##
##..##..
##..##..
##..##..
..##..##
..##..##
..##..##
##..##..
##..##..
##..##..
")]
        [TestCase(
            @"5 1 5
",
            @".....#####.....#####.....
#####.....#####.....#####
.....#####.....#####.....
#####.....#####.....#####
.....#####.....#####.....
")]
        [TestCase(
            @"4 4 1
",
            @".#.#
.#.#
.#.#
.#.#
#.#.
#.#.
#.#.
#.#.
.#.#
.#.#
.#.#
.#.#
#.#.
#.#.
#.#.
#.#.
")]
        [TestCase(
            @"1 4 4
",
            @"....
....
....
....
")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"5 5
1
2
3
4
5
",
            @"1 2 3 5 4
")]
        [TestCase(
            @"7 7
7
7
7
7
7
7
7
",
            @"1 2 3 4 5 7 6
")]
        [TestCase(
            @"10 6
1
5
2
9
6
6
",
            @"1 2 3 4 5 7 6 8 10 9
")]
        public void CTest(string input, string output)
        {
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"250
",
            @"2
")]
        [TestCase(
            @"1
",
            @"0
")]
        [TestCase(
            @"123456789012345
",
            @"226863
")]
        public void DTest(string input, string output)
        {
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"5
1 2 3 4 5
1 2 2 4 3
7
1 1
2 2
2 3
3 3
4 4
4 5
5 5
",
            @"Yes
Yes
Yes
No
No
Yes
No
")]

        public void ETest(string input, string output)
        {
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"5
3 0
2 3
-1 3
-3 1
-1 -1
",
            @"1
")]
        [TestCase(
            @"4
400000000 400000000
-400000000 400000000
-400000000 -400000000
400000000 -400000000
",
            @"1280000000000000000
")]
        [TestCase(
            @"6
-816 222
-801 -757
-165 -411
733 131
835 711
-374 979
",
            @"157889
")]
        public void FTest(string input, string output)
        {
            Utility.InOutTest(Tasks.F.Solve, input, output);
        }
    }
}
