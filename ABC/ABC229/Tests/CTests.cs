using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"3 5
3 1
4 2
2 3
";
            const string output = @"15
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"4 100
6 2
1 5
3 9
8 7
";
            const string output = @"100
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"10 3141
314944731 649
140276783 228
578012421 809
878510647 519
925326537 943
337666726 611
879137070 306
87808915 39
756059990 244
228622672 291
";
            const string output = @"2357689932073
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
