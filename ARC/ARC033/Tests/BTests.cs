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
            const string input = @"3 2
1 3 5
1 2";
            const string output = @"0.2500000000";
            Tester.InOutTest(Tasks.B.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"9 10
11 2 33 4 55 6 77 8 99
10 11 14 19 55 1000000000 4 5 7 8";
            const string output = @"0.2666666667";
            Tester.InOutTest(Tasks.B.Solve, input, output, RelativeError);
        }
    }
}
