using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BNTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-7;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"2
1 2
1 2
";
            const string output = @"0.250000000000
";
            Tester.InOutTest(Tasks.BN.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"3
3 3
1 1
4 4
";
            const string output = @"1.000000000000
";
            Tester.InOutTest(Tasks.BN.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"10
1 10
38 40
8 87
2 9
75 100
45 50
89 92
27 77
23 88
62 81
";
            const string output = @"13.696758921226
";
            Tester.InOutTest(Tasks.BN.Solve, input, output, RelativeError);
        }
    }
}
