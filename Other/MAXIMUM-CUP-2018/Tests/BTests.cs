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
            const string input = @"3 3
7 7
#######
#.#..##
#..#..#
##...##
#..#..#
##..#.#
#######
";
            const string output = @"Yes
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"4 3
5 7
#######
#.#..##
#...#.#
#.#...#
#######
";
            const string output = @"No
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
