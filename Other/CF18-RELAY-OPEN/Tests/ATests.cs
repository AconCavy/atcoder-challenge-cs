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
            const string input = @"8
Fri
Tue
Sun
Sun
Mon
Sun
Wed
Thu
";
            const string output = @"Sat
Wed
Mon
Mon
Tue
Mon
Thu
Fri
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }
    }
}
