using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-6;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"30 500 20 103
";
            const string output = @"0.042553191489
";
            Utility.InOutTest(Tasks.A.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"50 500 100 1
";
            const string output = @"1.000000000000
";
            Utility.InOutTest(Tasks.A.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"1 2 1 1000
";
            const string output = @"0.000000000000
";
            Utility.InOutTest(Tasks.A.Solve, input, output, RelativeError);
        }
    }
}
