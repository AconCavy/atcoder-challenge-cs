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
            const string input = @"6
1
5
6
3
2
6
";
            const string output = @"6 4
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"7
5
4
3
2
7
6
1
";
            const string output = @"Correct
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }
    }
}
