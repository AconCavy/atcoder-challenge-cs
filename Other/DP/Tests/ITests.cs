using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ITests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"3
0.30 0.60 0.80
";
            const string output = @"0.612
";
            Tester.InOutTest(Tasks.I.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"1
0.50
";
            const string output = @"0.5
";
            Tester.InOutTest(Tasks.I.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"5
0.42 0.01 0.42 0.99 0.42
";
            const string output = @"0.3821815872
";
            Tester.InOutTest(Tasks.I.Solve, input, output, RelativeError);
        }
    }
}
