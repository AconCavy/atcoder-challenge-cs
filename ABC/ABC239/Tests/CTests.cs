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
            const string input = @"0 0 3 3
";
            const string output = @"Yes
";
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"0 1 2 3
";
            const string output = @"No
";
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"1000000000 1000000000 999999999 999999999
";
            const string output = @"Yes
";
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
