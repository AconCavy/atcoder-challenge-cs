using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"3
4 3 5
2 1 3
3 2 4
";
            const string output = @"Yes
3 1 2
1 0 2
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"3
4 3 5
2 2 3
3 2 4
";
            const string output = @"No
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
