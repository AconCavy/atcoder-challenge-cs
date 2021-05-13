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
            const string input = @"3 3 3
06H
H14
257
337
15H
2H8
829
653
470
";
            const string output = @"9
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"2 5 3
013
871
7HH
163
92H
959
248
792
447
550
";
            const string output = @"14
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }
    }
}
