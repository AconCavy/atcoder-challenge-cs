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
1 3 5 2
2 3 1 4
";
            const string output = @"1
2
";
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"3
1 2 3
4 5 6
";
            const string output = @"0
0
";
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"7
4 8 1 7 9 5 6
3 5 1 7 8 2 6
";
            const string output = @"3
2
";
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
