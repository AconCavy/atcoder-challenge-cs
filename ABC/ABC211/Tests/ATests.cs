using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-5;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"130 100
";
            const string output = @"110
";
            Tester.InOutTest(Tasks.A.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"300 50
";
            const string output = @"133.3333333
";
            Tester.InOutTest(Tasks.A.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"123 123
";
            const string output = @"123
";
            Tester.InOutTest(Tasks.A.Solve, input, output, RelativeError);
        }
    }
}
