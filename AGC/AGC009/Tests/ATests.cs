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
            const string input = @"3
3 5
2 7
9 4
";
            const string output = @"7
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"7
3 1
4 1
5 9
2 6
5 3
5 8
9 7
";
            const string output = @"22
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }
    }
}
