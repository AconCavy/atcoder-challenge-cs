using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"4 3
2 1
3 4
2 4
";
            const string output = @"2 1 3 4
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"2 3
1 2
1 2
2 1
";
            const string output = @"-1
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }
    }
}
