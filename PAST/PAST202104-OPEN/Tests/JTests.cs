using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class JTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"3 2
3 0
3 1
3 3
";
            const string output = @"6.000000000000000
";
            Tester.InOutTest(Tasks.J.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"2 100000
-100000 100000
-100000 100000
";
            const string output = @"0.000000000000000
";
            Tester.InOutTest(Tasks.J.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"13 -2
3 -6
-4 7
-8 -8
2 9
1 -3
0 4
-6 6
7 0
1 0
-9 7
6 -1
-7 -2
5 6
";
            const string output = @"873.769230769230717
";
            Tester.InOutTest(Tasks.J.Solve, input, output, RelativeError);
        }
    }
}
