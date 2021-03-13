using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class STests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"30
4
";
            const string output = @"6
";
            Tester.InOutTest(Tasks.S.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"1000000009
1
";
            const string output = @"2
";
            Tester.InOutTest(Tasks.S.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"98765432109876543210
58
";
            const string output = @"635270834
";
            Tester.InOutTest(Tasks.S.Solve, input, output);
        }
    }
}
