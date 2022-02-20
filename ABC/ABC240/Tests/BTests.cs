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
            const string input = @"6
1 4 1 2 2 1
";
            const string output = @"3
";
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"1
1
";
            const string output = @"1
";
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"11
3 1 4 1 5 9 2 6 5 3 5
";
            const string output = @"7
";
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
