using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"4 4 2 2
##..
...#
#.#.
.#.#
";
            const string output = @"4
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"3 5 1 4
#....
#####
....#
";
            const string output = @"4
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"5 5 4 2
.#..#
#.###
##...
#..#.
#.###
";
            const string output = @"3
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
