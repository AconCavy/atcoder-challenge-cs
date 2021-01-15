using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-6;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"6 2 3 1 5
";
            const string output = @"0.8000000000
";
            Tester.InOutTest(Tasks.A.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"6 2 10 1 5
";
            const string output = @"0.2500000000
";
            Tester.InOutTest(Tasks.A.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"6 3 1 5 3
";
            const string output = @"1.0000000000
";
            Tester.InOutTest(Tasks.A.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"10 7 7 6 0
";
            const string output = @"0.2857142857
";
            Tester.InOutTest(Tasks.A.Solve, input, output, RelativeError);
        }
    }
}
