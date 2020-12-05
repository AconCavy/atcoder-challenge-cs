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
            const string input = @"34
ABABAAABACDDDABADFFABABDABFAAABFAA";
            const string output = @"2.79411764705882";
            Tester.InOutTest(Tasks.A.Solve, input, output, RelativeError);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"5
FFFFF";
            const string output = @"0";
            Tester.InOutTest(Tasks.A.Solve, input, output, RelativeError);
        }
    }
}
