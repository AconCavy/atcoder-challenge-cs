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
            const string input = @"3 3
s52
743
32g";
            const string output = @"2.910897";
            Tester.InOutTest(Tasks.C.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"4 6
g31784
621415
627914
7451s3";
            const string output = @"2.97";
            Tester.InOutTest(Tasks.C.Solve, input, output, RelativeError);
        }
    }
}
