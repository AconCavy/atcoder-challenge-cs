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
            const string input = @"4 5
1 2
1 3
3 2
2 4
3 4
";
            const string output = @"3
";
            Tester.InOutTest(Tasks.G.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"6 3
2 3
4 5
5 6
";
            const string output = @"2
";
            Tester.InOutTest(Tasks.G.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"5 8
5 3
2 3
2 4
5 2
5 1
1 4
4 3
1 3
";
            const string output = @"3
";
            Tester.InOutTest(Tasks.G.Solve, input, output);
        }
    }
}
