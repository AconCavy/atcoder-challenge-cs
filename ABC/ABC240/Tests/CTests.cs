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
            const string input = @"2 10
3 6
4 5
";
            const string output = @"Yes
";
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"2 10
10 100
10 100
";
            const string output = @"No
";
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"4 12
1 8
5 7
3 4
2 6
";
            const string output = @"Yes
";
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
