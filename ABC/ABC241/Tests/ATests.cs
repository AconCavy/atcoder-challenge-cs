using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"9 0 1 2 3 4 5 6 7 8
";
            const string output = @"7
";
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"4 8 8 8 0 8 8 8 8 8
";
            const string output = @"4
";
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"0 0 0 0 0 0 0 0 0 0
";
            const string output = @"0
";
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }
    }
}
