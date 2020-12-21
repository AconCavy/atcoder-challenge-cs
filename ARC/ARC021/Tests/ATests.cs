using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"2 8 2 2
32 2 8 8
4 64 2 128
2 8 4 2
";
            const string output = @"CONTINUE
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"2 4 16 4
8 32 128 8
2 64 16 2
32 4 32 4
";
            const string output = @"GAMEOVER
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"2 4 2 4
4 2 4 2
2 4 2 4
4 2 4 2
";
            const string output = @"GAMEOVER
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }
    }
}
