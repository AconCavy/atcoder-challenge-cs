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
            const string input = @"2 3 3
2 2
RRL
LUD
";
            const string output = @"YES
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"4 3 5
2 2
UDRRR
LLDUD
";
            const string output = @"NO
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"5 6 11
2 1
RLDRRUDDLRL
URRDRLLDLRD
";
            const string output = @"NO
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
