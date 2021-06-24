using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"240
600
1800
3600
4800
7200
10000
0
";
            const string output = @"10000
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"10400
10300
10100
9800
9500
8500
7000
5000
";
            const string output = @"10400
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"0
0
0
0
0
0
0
0
";
            const string output = @"0
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }
    }
}
