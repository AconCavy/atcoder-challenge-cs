using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"4
3
10 3
12 4
15 5
";
            const string output = @"50
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"8
4
1 1
10 1
100 1
1000 1
";
            const string output = @"36
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
