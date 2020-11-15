using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-6;

        [TestMethod, Timeout(TimeLimit)]
        public void TestMethod1()
        {
            const string input = @"1 1 7 2";
            const string output = @"3.0000000000";
            Tester.InOutTest(Tasks.B.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void TestMethod2()
        {
            const string input = @"1 1 3 2";
            const string output = @"1.6666666667";
            Tester.InOutTest(Tasks.B.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void TestMethod3()
        {
            const string input = @"-9 99 -999 9999";
            const string output = @"-18.7058823529";
            Tester.InOutTest(Tasks.B.Solve, input, output, RelativeError);
        }
    }
}
