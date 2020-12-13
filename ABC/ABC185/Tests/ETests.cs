using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ETests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"4 3
1 2 1 3
1 3 1
";
            const string output = @"2
";
            Tester.InOutTest(Tasks.E.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"4 6
1 3 2 4
1 5 2 6 4 3
";
            const string output = @"3
";
            Tester.InOutTest(Tasks.E.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"5 5
1 1 1 1 1
2 2 2 2 2
";
            const string output = @"5
";
            Tester.InOutTest(Tasks.E.Solve, input, output);
        }
    }
}
