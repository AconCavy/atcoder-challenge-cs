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
            const string input = @"3 4
1 2
2 1
3 1
2 3
";
            const string output = @"5
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"4 10
1 1
1 2
1 3
2 1
2 2
2 4
3 3
3 4
4 1
4 3
";
            const string output = @"47
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
