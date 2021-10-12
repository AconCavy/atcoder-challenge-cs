using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"3 4
#.##
..#.
#...
";
            const string output = @"1333
2433
1211
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"10 12
#.##..#...##
#..#..##...#
##.#....##.#
.#..###...#.
#..#..#...##
###...#..###
.###.#######
.#..#....###
.#.##..####.
.###....#..#
";
            const string output = @"233322331133
455432343354
444344443343
444344332454
454335431465
466434554686
466434445796
346554457885
346542135664
235431134432
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
