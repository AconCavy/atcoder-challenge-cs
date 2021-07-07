using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class TTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"4 3 2
";
            const string output = @"Yes
";
            Tester.InOutTest(Tasks.T.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"16 3 2
";
            const string output = @"No
";
            Tester.InOutTest(Tasks.T.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"8 3 2
";
            const string output = @"No
";
            Tester.InOutTest(Tasks.T.Solve, input, output);
        }
    }
}
