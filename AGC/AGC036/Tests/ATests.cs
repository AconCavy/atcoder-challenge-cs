using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"3
";
            const string output = @"0 0 1000000000 1 999999997 1
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"100
";
            const string output = @"0 0 1000000000 1 999999900 1
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"311114770564041497
";
            const string output = @"0 0 1000000000 1 435958503 311114771
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }
    }
}
