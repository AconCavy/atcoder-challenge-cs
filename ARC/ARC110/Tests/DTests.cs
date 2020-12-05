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
            const string input = @"3 5
1 2 1
";
            const string output = @"8
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"10 998244353
31 41 59 26 53 58 97 93 23 84
";
            const string output = @"642612171
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }
    }
}
