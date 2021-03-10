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
            const string input = @"4
1 1 0 2";
            const string output = @"0
0
2
3";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"10
5 4 3 2 1 0 7 7 6 6";
            const string output = @"0
0
0
0
0
6
6
6
8
8";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
