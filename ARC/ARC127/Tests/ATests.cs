using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        const int TimeLimit = 3000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"11
";
            const string output = @"4
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"120
";
            const string output = @"44
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"987654321
";
            const string output = @"123456789
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }
    }
}
