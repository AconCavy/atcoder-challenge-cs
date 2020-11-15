using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void TestMethod1()
        {
            const string input = @"4 10
1 3 5
2 4 4
3 10 6
2 4 1";
            const string output = @"No";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void TestMethod2()
        {
            const string input = @"4 10
1 3 5
2 4 4
3 10 6
2 3 1";
            const string output = @"Yes";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void TestMethod3()
        {
            const string input = @"6 1000000000
0 200000 999999999
2 20 1
20 200 1
200 2000 1
2000 20000 1
20000 200000 1";
            const string output = @"Yes";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }
    }
}
