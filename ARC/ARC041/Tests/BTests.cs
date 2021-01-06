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
            const string input = @"3 3
010
101
010
";
            const string output = @"000
010
000
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"3 4
0230
2323
0230
";
            const string output = @"0000
0230
0000
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"5 5
00100
03040
20903
05060
00300
";
            const string output = @"00000
00100
02030
00300
00000
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
