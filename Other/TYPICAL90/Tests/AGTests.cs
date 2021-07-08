using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class AGTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"2 3
";
            const string output = @"2
";
            Tester.InOutTest(Tasks.AG.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"3 4
";
            const string output = @"4
";
            Tester.InOutTest(Tasks.AG.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"3 6
";
            const string output = @"6
";
            Tester.InOutTest(Tasks.AG.Solve, input, output);
        }
    }
}
