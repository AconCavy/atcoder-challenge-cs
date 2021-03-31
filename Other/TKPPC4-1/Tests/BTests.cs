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
            const string input = @"4 10
11 9 15 13";
            const string output = @"2";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"5 10000
763618767 814402216 467921615 163029185 204341760";
            const string output = @"-1";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
