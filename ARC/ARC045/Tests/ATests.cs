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
            const string input = @"Left Right AtCoder
";
            const string output = @"< > A
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"Left Left Right Right AtCoder
";
            const string output = @"< < > > A
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"Right Right AtCoder Left Left AtCoder
";
            const string output = @"> > A < < A
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }
    }
}
