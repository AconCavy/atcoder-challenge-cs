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
            const string input = @"MRHAGIYA
";
            const string output = @"MRHAGIXILE
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }
    }
}
