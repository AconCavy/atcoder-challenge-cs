using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void TestMethod1()
        {
            const string input = @"2 10000000
10000000 10000000
";
            const string output = @"0.125
";
            Tester.InOutTest(Tasks.D.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void TestMethod2()
        {
            const string input = @"100 2
3 7
";
            const string output = @"0.0
";
            Tester.InOutTest(Tasks.D.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void TestMethod3()
        {
            const string input = @"11 8562174
25686522 17124348
";
            const string output = @"0.018174648284912
";
            Tester.InOutTest(Tasks.D.Solve, input, output, RelativeError);
        }
    }
}
