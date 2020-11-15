using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class FTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void TestMethod1()
        {
            const string input = @"5 5
1 2 3 2 1
1 1 2
1 2 5
2 1 1
1 3 4
2 3 4";
            const string output = @"2
0";
            Tester.InOutTest(Tasks.F.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void TestMethod2()
        {
            const string input = @"5 4
2 2 2 2 2
1 1 2
1 1 3
1 2 3
2 2 2";
            const string output = @"3";
            Tester.InOutTest(Tasks.F.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void TestMethod3()
        {
            const string input = @"12 9
1 2 3 1 2 3 1 2 3 1 2 3
1 1 2
1 3 4
1 5 6
1 7 8
2 2 1
1 9 10
2 5 6
1 4 8
2 6 1";
            const string output = @"1
0
0";
            Tester.InOutTest(Tasks.F.Solve, input, output);
        }
    }
}
