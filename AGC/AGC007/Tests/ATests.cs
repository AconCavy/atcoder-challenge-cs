using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"4 5
##...
.##..
..##.
...##
";
            const string output = @"Possible
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"5 3
###
..#
###
#..
###
";
            const string output = @"Impossible
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"4 5
##...
.###.
.###.
...##
";
            const string output = @"Impossible
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }
    }
}
