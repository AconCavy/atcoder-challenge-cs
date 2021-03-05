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
            const string input = @"6 5
1 2
2 3
3 4
4 5
5 6
";
            const string output = @"4
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"5 5
1 2
2 3
3 1
5 4
5 1
";
            const string output = @"5
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
