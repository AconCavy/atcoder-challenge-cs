using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class GTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"3 3
##.
.##
###
";
            const string output = @"7
1 1
1 2
2 2
2 3
3 3
3 2
3 1
";
            Tester.InOutTest(Tasks.G.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"3 4
####
####
.#..
";
            const string output = @"9
1 4
2 4
2 3
1 3
1 2
1 1
2 1
2 2
3 2
";
            Tester.InOutTest(Tasks.G.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"3 3
.##
###
###
";
            const string output = @"8
1 2
1 3
2 3
2 2
2 1
3 1
3 2
3 3
";
            Tester.InOutTest(Tasks.G.Solve, input, output);
        }
    }
}
