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
            const string input = @"3
2 1
3 1
";
            const string output = @"1 2
1 1
2 2
";
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"5
3 4
5 4
1 2
1 4
";
            const string output = @"1 3
1 1
2 2
2 3
3 3
";
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"5
4 5
3 2
5 2
3 1
";
            const string output = @"1 1
1 1
1 1
1 1
1 1
";
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }
    }
}
