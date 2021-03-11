using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-6;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"1
2200
2600";
            const string output = @"0.090909091
0.909090909";
            Tester.InOutTest(Tasks.C.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"3
2000
2500
2300
2700
2100
2400
2600
2200";
            const string output = @"0.000086893
0.122042976
0.005522752
0.493464665
0.000651695
0.053982389
0.321828438
0.002420190";
            Tester.InOutTest(Tasks.C.Solve, input, output, RelativeError);
        }
    }
}
