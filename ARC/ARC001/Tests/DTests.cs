using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"7
3 3
2 5
4 6
2 3
3 6
3 4
4 6
2 5
1 5";
            const string output = @"8.22677276241436";
            Tester.InOutTest(Tasks.D.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"5
3 3
0 5
0 5
0 5
0 5
0 5
0 5";
            const string output = @"5";
            Tester.InOutTest(Tasks.D.Solve, input, output, RelativeError);
        }
    }
}
