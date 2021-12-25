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
            const string input = @"6 5
8 -3 5 7 0 -4
";
            const string output = @"3
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"2 -1000000000000000
1000000000 -1000000000
";
            const string output = @"0
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }
    }
}
