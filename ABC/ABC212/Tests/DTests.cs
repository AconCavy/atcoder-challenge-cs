using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"5
1 3
1 5
3
2 2
3
";
            const string output = @"3
7
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"6
1 1000000000
2 1000000000
2 1000000000
2 1000000000
2 1000000000
3
";
            const string output = @"5000000000
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }
    }
}
