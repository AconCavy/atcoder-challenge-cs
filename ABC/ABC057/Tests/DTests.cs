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
            const string input = @"5 2 2
1 2 3 4 5
";
            const string output = @"4.500000
1
";
            Tester.InOutTest(Tasks.D.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void TestMethod2()
        {
            const string input = @"4 2 3
10 20 10 10
";
            const string output = @"15.000000
3
";
            Tester.InOutTest(Tasks.D.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void TestMethod3()
        {
            const string input = @"5 1 5
1000000000000000 999999999999999 999999999999998 999999999999997 999999999999996
";
            const string output = @"1000000000000000.000000
1
";
            Tester.InOutTest(Tasks.D.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void TestMethod4()
        {
            const string input = @"50 1 50
1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1
";
            const string output = @"1.000000
1125899906842623
";
            Tester.InOutTest(Tasks.D.Solve, input, output, RelativeError);
        }
    }
}
