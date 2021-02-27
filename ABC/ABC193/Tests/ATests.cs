using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-2;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"100 80
";
            const string output = @"20.0
";
            Tester.InOutTest(Tasks.A.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"7 6
";
            const string output = @"14.285714285714285714
";
            Tester.InOutTest(Tasks.A.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"99999 99998
";
            const string output = @"0.00100001000010000100
";
            Tester.InOutTest(Tasks.A.Solve, input, output, RelativeError);
        }
    }
}
