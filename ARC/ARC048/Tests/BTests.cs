using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"6
2 1
2 2
3 2
5 3
2 2
3 3
";
            const string output = @"2 3 0
0 4 1
4 1 0
5 0 0
0 4 1
3 2 0
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"2
1999 3
2000 1
";
            const string output = @"0 1 0
1 0 0
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"8
3200 2
2800 3
2800 2
2700 1
2800 2
3200 1
2700 1
3200 3
";
            const string output = @"6 1 0
2 5 0
3 3 1
0 6 1
3 3 1
6 1 0
0 6 1
6 1 0
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
