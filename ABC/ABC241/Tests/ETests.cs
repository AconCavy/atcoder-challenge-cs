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
            const string input = @"5 3
2 1 6 3 1
";
            const string output = @"11
";
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"10 1000000000000
260522 914575 436426 979445 648772 690081 933447 190629 703497 47202
";
            const string output = @"826617499998784056
";
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }
    }
}
