using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"eye lid
4
lie
die
did
dye";
            const string output = @"3
eye
dye
die
lie
lid";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"eye eye
4
lie
die
did
dye";
            const string output = @"0
eye
eye";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"eye lid
4
lie
lip
did
dye";
            const string output = @"-1";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
