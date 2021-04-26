using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"5 4
1 4 5 8 10
3
4
7
11
";
            const string output = @"17
14
15
27
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"8 10
-499 -120 32 255 571 890 1011 1256
0
-200
2500
364
-117
50
-612
889
32
364
";
            const string output = @"4634
5594
16604
4060
5102
4470
8292
4696
4506
4060
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }
    }
}
