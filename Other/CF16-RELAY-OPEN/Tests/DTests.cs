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
            const string input = @"8
3
5
";
            const string output = @"8 3 4
1 5 9
6 7 2
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"1
1
1
";
            const string output = @"1 1 1
1 1 1
1 1 1
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }
    }
}
