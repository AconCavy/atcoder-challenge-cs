using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-6;

        [TestMethod, Timeout(TimeLimit)]
        public void TestMethod1()
        {
            const string input = @"4
0 0
0 1
1 0
1 1
0 2
2 0
-2 0
0 -2
";
            const string output = @"2.8284271247
";
            Tester.InOutTest(Tasks.D.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void TestMethod2()
        {
            const string input = @"6
3 4
1 3
4 3
2 2
0 1
2 0
5 5
-1 2
-1 -3
2 1
2 6
4 -3
";
            const string output = @"2.2360679775
";
            Tester.InOutTest(Tasks.D.Solve, input, output, RelativeError);
        }
    }
}
