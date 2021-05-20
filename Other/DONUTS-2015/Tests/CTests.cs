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
            const string input = @"5
2 5 3 4 1
";
            const string output = @"0
1
1
2
2
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"1
1000000
";
            const string output = @"0
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"8
66 52 56 32 27 50 72 23
";
            const string output = @"0
1
2
2
3
4
3
1
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
