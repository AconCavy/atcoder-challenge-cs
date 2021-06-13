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
            const string input = @"2 3 3
1 1 2 2
1 2 2 3
1 1 1 3
";
            const string output = @"2
";
            Tester.InOutTest(Tasks.F.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"5 5 3
1 1 5 5
1 1 4 4
2 2 3 3
";
            const string output = @"3
";
            Tester.InOutTest(Tasks.F.Solve, input, output);
        }
    }
}
