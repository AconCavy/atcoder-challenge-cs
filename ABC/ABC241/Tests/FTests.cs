using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class FTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"7 8 7
3 4
5 6
1 4
2 1
2 8
4 5
5 7
6 2
6 6
";
            const string output = @"4
";
            Utility.InOutTest(Tasks.F.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"4 6 2
3 2
3 5
4 5
2 5
";
            const string output = @"-1
";
            Utility.InOutTest(Tasks.F.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"1 10 1
1 5
1 1
1 7
";
            const string output = @"-1
";
            Utility.InOutTest(Tasks.F.Solve, input, output);
        }
    }
}
