using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ETests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"2 2 2
1 2 2 1
";
            const string output = @"2
";
            Tester.InOutTest(Tasks.E.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"1000000000 1000000000 1000000
1000000000 1000000000 1000000000 1000000000
";
            const string output = @"24922282
";
            Tester.InOutTest(Tasks.E.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"3 3 3
1 3 3 3
";
            const string output = @"9
";
            Tester.InOutTest(Tasks.E.Solve, input, output);
        }
    }
}
