using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-6;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"0 0
4
100 100
-100 100
-100 -100
100 -100
";
            const string output = @"100
";
            Tester.InOutTest(Tasks.B.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"10 10
3
0 100
-100 -100
100 -100
";
            const string output = @"31.3049516850
";
            Tester.InOutTest(Tasks.B.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"34 6
7
-43 -65
-23 -99
54 -68
65 92
16 83
-18 43
-39 2
";
            const string output = @"25.0284205314
";
            Tester.InOutTest(Tasks.B.Solve, input, output, RelativeError);
        }
    }
}
