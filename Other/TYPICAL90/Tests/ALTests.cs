using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ALTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"4 6
";
            const string output = @"12
";
            Tester.InOutTest(Tasks.AL.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"1000000000000000000 3
";
            const string output = @"Large
";
            Tester.InOutTest(Tasks.AL.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"1000000000000000000 1
";
            const string output = @"1000000000000000000
";
            Tester.InOutTest(Tasks.AL.Solve, input, output);
        }
    }
}
