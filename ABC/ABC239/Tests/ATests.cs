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
            const string input = @"333
";
            const string output = @"65287.907678222
";
            Utility.InOutTest(Tasks.A.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"634
";
            const string output = @"90086.635834623
";
            Utility.InOutTest(Tasks.A.Solve, input, output, RelativeError);
        }
    }
}
