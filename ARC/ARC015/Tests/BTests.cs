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
            const string input = @"4
32.2 25.3
36.4 26.4
24.1 18.0
26.0 24.9";
            const string output = @"1 1 1 2 0 0";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"3
-2 -5.2
2 -0.1
26.0 -0.1";
            const string output = @"0 0 1 0 2 1";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"4
15.0 9.5
12.5 10.5
20.5 19.9
15.5 15.5";
            const string output = @"0 0 0 0 0 0";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
