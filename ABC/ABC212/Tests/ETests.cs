using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ETests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"3 1 4
2 3
";
            const string output = @"4
";
            Tester.InOutTest(Tasks.E.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"3 3 3
1 2
1 3
2 3
";
            const string output = @"0
";
            Tester.InOutTest(Tasks.E.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"5 3 100
1 2
4 5
2 3
";
            const string output = @"428417047
";
            Tester.InOutTest(Tasks.E.Solve, input, output);
        }
    }
}
