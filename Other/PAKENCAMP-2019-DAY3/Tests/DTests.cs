using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"1
B
R
#
W
B
";
            const string output = @"3
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"3
WWR
#RW
BW#
##B
RBR
";
            const string output = @"10
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"8
RRRRRRRR
########
BBBBBBBB
RRRRRRRR
WWWWWWWW
";
            const string output = @"28
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"7
BR#WB#R
RWW#WRB
##WBR#W
WB#B#RW
BRW##BB
";
            const string output = @"21
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }
    }
}
