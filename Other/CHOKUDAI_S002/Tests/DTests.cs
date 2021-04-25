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
            const string input = @"2
20 19
1 100
";
            const string output = @"120
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"3
123456789 987654321
999999999 999999999
1000000000 888888888
";
            const string output = @"2987654320
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }
    }
}
