using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class MTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"3 2
1 2
2 3
2
2
1 3
";
            const string output = @"3
";
            Tester.InOutTest(Tasks.M.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"5 5
1 2
1 3
1 4
1 5
2 3
1
3
2 3 5
";
            const string output = @"4
";
            Tester.InOutTest(Tasks.M.Solve, input, output);
        }
    }
}
