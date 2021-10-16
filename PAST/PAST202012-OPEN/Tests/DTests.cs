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
            const string input = @"5
2
1
01
1
0010
";
            const string output = @"01
1
1
2
0010
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"6
1111111111111111111111
00011111111111111111111
000000111111111111111111
0000000001111111111111111
00000000000011111111111111
000000000000000111111111111
";
            const string output = @"000000000000000111111111111
00000000000011111111111111
0000000001111111111111111
000000111111111111111111
00011111111111111111111
1111111111111111111111
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }
    }
}
