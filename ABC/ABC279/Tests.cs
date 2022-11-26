using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"vvwvw
",
            @"7
")]
        [TestCase(
            @"v
",
            @"1
")]
        [TestCase(
            @"wwwvvvvvv
",
            @"12
")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"voltage
tag
",
            @"Yes
")]
        [TestCase(
            @"atcoder
ace
",
            @"No
")]
        [TestCase(
            @"gorilla
gorillagorillagorilla
",
            @"No
")]
        [TestCase(
            @"toyotasystems
toyotasystems
",
            @"Yes
")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3 4
##.#
##..
#...
.###
..##
...#
",
            @"Yes
")]
        [TestCase(
            @"3 3
#.#
.#.
#.#
##.
##.
.#.
",
            @"No
")]
        [TestCase(
            @"2 1
#
.
#
.
",
            @"Yes
")]
        [TestCase(
            @"8 7
#..#..#
.##.##.
#..#..#
.##.##.
#..#..#
.##.##.
#..#..#
.##.##.
....###
####...
....###
####...
....###
####...
....###
####...
",
            @"Yes
")]
        public void CTest(string input, string output)
        {
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"10 1
",
            @"7.7735026919
")]
        [TestCase(
            @"5 10
",
            @"5.0000000000
")]
        [TestCase(
            @"1000000000000000000 100
",
            @"8772053214538.5976562500
")]
        public void DTest(string input, string output)
        {
            Utility.InOutTest(Tasks.D.Solve, input, output, 1e-6);
        }

        [Timeout(2000)]
        [TestCase(
            @"5 4
1 2 3 2
",
            @"1
3
2
4
")]
        [TestCase(
            @"3 3
2 2 2
",
            @"1
1
1
")]
        [TestCase(
            @"10 10
1 1 1 9 4 4 2 1 3 3
",
            @"2
2
2
3
3
3
1
3
4
4
")]
        public void ETest(string input, string output)
        {
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"5 10
3 5
1 1 4
2 1
2 4
3 7
1 3 1
3 4
1 1 4
3 7
3 6
",
            @"5
4
3
1
3
")]
        public void FTest(string input, string output)
        {
            Utility.InOutTest(Tasks.F.Solve, input, output);
        }
    }
}
