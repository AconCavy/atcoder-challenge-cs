using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class FTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"3 9999999999
3 6 8
";
            const string output = @"4999999994
";
            Tester.InOutTest(Tasks.F.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"1 1000000000000000000
1
";
            const string output = @"999999999999999999
";
            Tester.InOutTest(Tasks.F.Solve, input, output);
        }
    }
}
