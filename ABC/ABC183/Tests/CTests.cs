using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void TestMethod1()
        {
            const string input = @"4 330
0 1 10 100
1 0 20 200
10 20 0 300
100 200 300 0";
            const string output = @"2";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void TestMethod2()
        {
            const string input = @"5 5
0 1 1 1 1
1 0 1 1 1
1 1 0 1 1
1 1 1 0 1
1 1 1 1 0";
            const string output = @"24";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
