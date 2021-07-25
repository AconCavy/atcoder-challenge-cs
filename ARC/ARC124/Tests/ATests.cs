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
            const string input = @"3 2
L 1
R 2
";
            const string output = @"1
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"30 10
R 6
R 8
R 7
R 25
L 26
L 13
R 14
L 11
L 23
R 30
";
            const string output = @"343921442
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }
    }
}
