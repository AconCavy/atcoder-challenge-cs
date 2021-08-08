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
            const string input = @"4
1 2
4 2
3 1
";
            const string output = @"1 2 4 2 1 3 1
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"5
1 2
1 3
1 4
1 5
";
            const string output = @"1 2 1 3 1 4 1 5 1
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }
    }
}
