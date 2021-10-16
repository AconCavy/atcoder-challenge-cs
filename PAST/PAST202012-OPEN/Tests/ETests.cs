using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ETests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"3 3
...
.#.
..#
#.#
###
...
";
            const string output = @"Yes
";
            Tester.InOutTest(Tasks.E.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"3 3
...
#..
#.#
.#.
.##
##.
";
            const string output = @"No
";
            Tester.InOutTest(Tasks.E.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"2 5
.....
..#..
..##.
.###.
";
            const string output = @"Yes
";
            Tester.InOutTest(Tasks.E.Solve, input, output);
        }
    }
}
