using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"CODEFESTIVAL
";
            const string output = @"CODE FESTIVAL
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"POSTGRADUATE
";
            const string output = @"POST GRADUATE
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"ABCDEFGHIJKL
";
            const string output = @"ABCD EFGHIJKL
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }
    }
}
