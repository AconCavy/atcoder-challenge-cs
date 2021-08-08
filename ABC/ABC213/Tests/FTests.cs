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
            const string input = @"3
abb
";
            const string output = @"3
3
2
";
            Tester.InOutTest(Tasks.F.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"11
mississippi
";
            const string output = @"11
16
14
12
13
11
9
7
4
3
4
";
            Tester.InOutTest(Tasks.F.Solve, input, output);
        }
    }
}
