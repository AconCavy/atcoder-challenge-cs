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
            const string input = @"4
3 1 4 5
4 1 5 3
";
            const string output = @"Yes
";
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"3
1 2 2
2 1 2
";
            const string output = @"Yes
";
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"3
1 2 3
2 3 4
";
            const string output = @"No
";
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
