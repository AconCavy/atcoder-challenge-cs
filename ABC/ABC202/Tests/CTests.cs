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
            const string input = @"3
1 2 2
3 1 2
2 3 2
";
            const string output = @"4
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"4
1 1 1 1
1 1 1 1
1 2 3 4
";
            const string output = @"16
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"3
2 3 3
1 3 3
1 1 1
";
            const string output = @"0
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
