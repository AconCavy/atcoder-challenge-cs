using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-3;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"1000
";
            const string output = @"10
";
            Tester.InOutTest(Tasks.A.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"50
";
            const string output = @"0.5
";
            Tester.InOutTest(Tasks.A.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"3141
";
            const string output = @"31.41
";
            Tester.InOutTest(Tasks.A.Solve, input, output, RelativeError);
        }
    }
}
