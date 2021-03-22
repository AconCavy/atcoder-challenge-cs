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
            const string input = @"25 10 800 250 6 4 15 7 5 5 17 31 334 777 616 88 919 331 270 27 555 555 555 1000 100 10
";
            const string output = @"15
1050
0
10
aaaji
6
1201670
720
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }
    }
}
