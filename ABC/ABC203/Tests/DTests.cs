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
            const string input = @"3 2
1 7 0
5 8 11
10 4 2
";
            const string output = @"4
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"3 3
1 2 3
4 5 6
7 8 9
";
            const string output = @"5
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }
    }
}
