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
            const string input = @"2 3
2 1
5 10
";
            const string output = @"4
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"5 1000000000
1 1000000000
2 1000000000
3 1000000000
4 1000000000
5 1000000000
";
            const string output = @"6000000000
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"3 2
5 5
2 1
2 2
";
            const string output = @"10
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
