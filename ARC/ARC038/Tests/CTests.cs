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
1 0
1 1
";
            const string output = @"Second
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"7
1 1
2 0
1 0
2 0
4 1
3 0
";
            const string output = @"First
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"7
1 1
2 0
1 9
2 10
4 3
3 5
";
            const string output = @"Second
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
