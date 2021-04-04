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
            const string input = @"5
70
10
50
20
";
            const string output = @"150
80
80
130
150
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"8
70
10
-2000
10000
-2000
50
20
";
            const string output = @"8080
8010
8000
10000
10000
8000
8050
8070
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"7
-45
-45
-45
-45
-45
-45
";
            const string output = @"0
0
0
0
0
0
0
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }
    }
}
