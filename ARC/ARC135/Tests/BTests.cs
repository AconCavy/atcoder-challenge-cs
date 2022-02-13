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
            const string input = @"5
6 9 6 6 5
";
            const string output = @"Yes
0 3 3 3 0 3 2
";
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"5
0 1 2 1 0
";
            const string output = @"No
";
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"1
10
";
            const string output = @"Yes
0 0 10
";
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"2
10 11
";
            const string output = @"Yes
0 0 10 1";
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
