using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"3 5
#....
.....
.##..
",
            @"3
")]
        [TestCase(
            @"1 10
..........
",
            @"0
")]
        [TestCase(
            @"6 5
#.#.#
....#
..##.
####.
..#..
#####
",
            @"16
")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3
3 4 8
",
            @"3 1 4
")]
        [TestCase(
            @"10
314159265 358979323 846264338 -327950288 419716939 -937510582 97494459 230781640 628620899 -862803482
",
            @"314159265 44820058 487285015 -1174214626 747667227 -1357227521 1035005041 133287181 397839259 -1491424381
")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"atcoder
atcorder
",
            @"5
")]
        [TestCase(
            @"million
milllion
",
            @"5
")]
        [TestCase(
            @"vvwvw
vvvwvw
",
            @"3
")]
        public void CTest(string input, string output)
        {
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"30
",
            @"5
")]
        [TestCase(
            @"123456789011
",
            @"123456789011
")]
        [TestCase(
            @"280
",
            @"7
")]
        public void DTest(string input, string output)
        {
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3 10
",
            @"229596204
")]
        [TestCase(
            @"5 100
",
            @"3
")]
        [TestCase(
            @"280 59
",
            @"567484387
")]
        public void ETest(string input, string output)
        {
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }
    }
}
