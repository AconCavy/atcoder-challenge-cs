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
            const string input = @"3 3
2 1 4
3 1 3
6 4 1
";
            const string output = @"Yes
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"2 4
4 3 2 1
5 6 7 8
";
            const string output = @"No
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
