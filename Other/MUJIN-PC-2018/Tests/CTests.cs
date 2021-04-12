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
            const string input = @"3 3
..#
...
#.#
";
            const string output = @"9
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"2 5
.#.#.
..#..
";
            const string output = @"2
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"6 8
#......#
##....##
#.#..#.#
#..##..#
#......#
#......#
";
            const string output = @"182
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
