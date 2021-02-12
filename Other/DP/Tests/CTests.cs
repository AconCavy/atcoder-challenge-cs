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
10 40 70
20 50 80
30 60 90
";
            const string output = @"210
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"1
100 10 1
";
            const string output = @"100
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"7
6 7 8
8 8 3
2 5 2
7 8 6
4 6 8
2 3 4
7 5 1
";
            const string output = @"46
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
