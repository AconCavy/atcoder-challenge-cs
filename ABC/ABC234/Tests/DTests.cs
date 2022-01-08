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
1 2 3
";
            const string output = @"1
2
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"11 5
3 7 2 5 11 6 1 9 8 10 4
";
            const string output = @"2
3
3
5
6
7
7
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }
    }
}
