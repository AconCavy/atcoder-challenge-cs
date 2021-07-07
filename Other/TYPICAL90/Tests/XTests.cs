using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class XTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"2 5
1 3
2 1
";
            const string output = @"Yes
";
            Tester.InOutTest(Tasks.X.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"3 1
7 8 9
7 8 9
";
            const string output = @"No
";
            Tester.InOutTest(Tasks.X.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"7 999999999
3 1 4 1 5 9 2
1 2 3 4 5 6 7
";
            const string output = @"Yes
";
            Tester.InOutTest(Tasks.X.Solve, input, output);
        }
    }
}
