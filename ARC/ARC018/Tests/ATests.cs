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
            const string input = @"160.0 23.5";
            const string output = @"60.160";
            Tester.InOutTest(Tasks.A.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"199.9 11.1";
            const string output = @"44.356";
            Tester.InOutTest(Tasks.A.Solve, input, output, RelativeError);
        }
    }
}
