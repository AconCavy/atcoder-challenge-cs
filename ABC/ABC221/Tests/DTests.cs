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
            const string input = @"3
1 2
2 3
3 1
";
            const string output = @"2 2 0
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"2
1000000000 1000000000
1000000000 1000000000
";
            const string output = @"0 1000000000
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }
    }
}
