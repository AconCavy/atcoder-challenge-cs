using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class LTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"3 2 2
3 1 4
";
            const string output = @"3 4
";
            Tester.InOutTest(Tasks.L.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"3 3 2
3 1 4
";
            const string output = @"-1
";
            Tester.InOutTest(Tasks.L.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"3 2 1
3 1 4
";
            const string output = @"1 4
";
            Tester.InOutTest(Tasks.L.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"4 2 2
3 6 5 5
";
            const string output = @"3 5
";
            Tester.InOutTest(Tasks.L.Solve, input, output);
        }
    }
}
