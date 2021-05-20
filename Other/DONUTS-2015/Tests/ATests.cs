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
            const string input = @"3 5
";
            const string output = @"888.264396
";
            Tester.InOutTest(Tasks.A.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"46 96
";
            const string output = @"4009743.9192393753
";
            Tester.InOutTest(Tasks.A.Solve, input, output, RelativeError);
        }
    }
}
