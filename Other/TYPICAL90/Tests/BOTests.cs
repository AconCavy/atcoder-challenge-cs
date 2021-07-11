using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BOTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"21 1
";
            const string output = @"15
";
            Tester.InOutTest(Tasks.BO.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"1330 1
";
            const string output = @"555
";
            Tester.InOutTest(Tasks.BO.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"2311640221315 15
";
            const string output = @"474547
";
            Tester.InOutTest(Tasks.BO.Solve, input, output);
        }
    }
}
