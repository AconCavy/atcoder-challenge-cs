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
            const string input = @"10
7 6
3 2
2 4
4 5
8 9
1 8
1 6
1 2
9 10";
            const string output = @"5 10";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"4
1 2
1 3
1 4";
            const string output = @"4 3";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
