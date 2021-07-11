using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BFTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"5 3
";
            const string output = @"13
";
            Tester.InOutTest(Tasks.BF.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"0 100
";
            const string output = @"0
";
            Tester.InOutTest(Tasks.BF.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"99999 1000000000000000000
";
            const string output = @"84563
";
            Tester.InOutTest(Tasks.BF.Solve, input, output);
        }
    }
}
