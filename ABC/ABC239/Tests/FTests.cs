using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class FTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"6 2
1 2 1 2 2 2
2 3
1 4
";
            const string output = @"5 6
5 4
2 6
";
            Utility.InOutTest(Tasks.F.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"5 1
1 1 1 1 4
2 3
";
            const string output = @"-1
";
            Utility.InOutTest(Tasks.F.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"4 0
3 3 3 3
";
            const string output = @"-1
";
            Utility.InOutTest(Tasks.F.Solve, input, output);
        }
    }
}
