using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class FTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"6
1 2 3 4 5 6
";
            const string output = @"12
";
            Tester.InOutTest(Tasks.F.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"5
-1000 -100 -10 0 10
";
            const string output = @"0
";
            Tester.InOutTest(Tasks.F.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"10
1000000000 1000000000 1000000000 1000000000 1000000000 1000000000 1000000000 1000000000 1000000000 1000000000
";
            const string output = @"5000000000
";
            Tester.InOutTest(Tasks.F.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"27
18 -28 18 28 -45 90 -45 23 -53 60 28 -74 -71 35 -26 -62 49 -77 57 24 -70 -93 69 -99 59 57 -49
";
            const string output = @"295
";
            Tester.InOutTest(Tasks.F.Solve, input, output);
        }
    }
}
