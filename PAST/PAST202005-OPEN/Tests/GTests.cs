using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class GTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"1 2 2
1 1
";
            const string output = @"3
";
            Tester.InOutTest(Tasks.G.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"1 2 2
2 1
";
            const string output = @"2
";
            Tester.InOutTest(Tasks.G.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"5 -2 3
1 1
-1 1
0 1
-2 1
-3 1
";
            const string output = @"6
";
            Tester.InOutTest(Tasks.G.Solve, input, output);
        }
    }
}
