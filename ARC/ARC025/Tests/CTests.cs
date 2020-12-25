using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        const int TimeLimit = 7000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"4 5 2 1
1 2 4
1 3 3
1 4 6
2 3 5
3 4 4
";
            const string output = @"2
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"5 4 7 7
1 2 1
2 3 1
3 4 1
4 5 1
";
            const string output = @"26
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
