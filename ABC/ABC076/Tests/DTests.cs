using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-3;

        [TestMethod, Timeout(TimeLimit)]
        public void TestMethod1()
        {
            const string input = @"1
100
30
";
            const string output = @"2100.000000000000000
";
            Tester.InOutTest(Tasks.D.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void TestMethod2()
        {
            const string input = @"2
60 50
34 38
";
            const string output = @"2632.000000000000000
";
            Tester.InOutTest(Tasks.D.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void TestMethod3()
        {
            const string input = @"3
12 14 2
6 2 7
";
            const string output = @"76.000000000000000
";
            Tester.InOutTest(Tasks.D.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void TestMethod4()
        {
            const string input = @"1
9
10
";
            const string output = @"20.250000000000000000
";
            Tester.InOutTest(Tasks.D.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void TestMethod5()
        {
            const string input = @"10
64 55 27 35 76 119 7 18 49 100
29 19 31 39 27 48 41 87 55 70
";
            const string output = @"20291.000000000000
";
            Tester.InOutTest(Tasks.D.Solve, input, output, RelativeError);
        }
    }
}
