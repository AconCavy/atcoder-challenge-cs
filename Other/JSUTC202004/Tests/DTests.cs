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
            const string input = @"4 3
6 12 6 9
4 6 3
";
            const string output = @"4
3
3
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"4 3
4 6 2 1
3 2 1000000000
";
            const string output = @"1
4
4
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }
    }
}
