using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"10
in that case you should print yes and not no
",
            @"Yes
",
            TestName = "{m}-1")]
        [TestCase(
            @"10
in diesem fall sollten sie no und nicht yes ausgeben
",
            @"No
",
            TestName = "{m}-2")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"4 4
.1.#
###.
.#2.
#.##
",
            @"...#
#...
....
#...
",
            TestName = "{m}-1")]
        [TestCase(
            @"2 5
..#.#
###.#
",
            @"..#.#
###.#
",
            TestName = "{m}-2")]
        [TestCase(
            @"2 3
11#
###
",
            @"...
..#
",
            TestName = "{m}-3")]
        [TestCase(
            @"4 6
#.#3#.
###.#.
##.###
#1..#.
",
            @"......
#.....
#....#
....#.
",
            TestName = "{m}-4")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"6
4 1 7 4 1 4
",
            @"2
",
            TestName = "{m}-1")]
        [TestCase(
            @"1
158260522
",
            @"0
",
            TestName = "{m}-2")]
        [TestCase(
            @"10
295 2 29 295 29 2 29 295 2 29
",
            @"4
",
            TestName = "{m}-3")]
        public void CTest(string input, string output)
        {
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"20230322
",
            @"4
",
            TestName = "{m}-1")]
        [TestCase(
            @"0112223333444445555556666666777777778888888889999999999
",
            @"185
",
            TestName = "{m}-2")]
        [TestCase(
            @"3141592653589793238462643383279502884197169399375105820974944
",
            @"9
",
            TestName = "{m}-3")]
        public void DTest(string input, string output)
        {
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3 5 2
2 0 4
",
            @"3
",
            TestName = "{m}-1")]
        [TestCase(
            @"2 3 1
0 0
",
            @"221832080
",
            TestName = "{m}-2")]
        [TestCase(
            @"10 20 7
6 5 0 2 0 0 0 15 0 0
",
            @"617586310
",
            TestName = "{m}-3")]
        public void ETest(string input, string output)
        {
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }
    }
}
