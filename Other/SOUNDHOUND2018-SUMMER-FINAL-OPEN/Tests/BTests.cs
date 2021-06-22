using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"9 3
-1
-2
-3
4
5
-6
-7
-8
-9
";
            const string output = @"9
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"5 4
-1
-1
5
-1
-1
";
            const string output = @"1
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"9 5
30
-20
40
60
-90
50
-40
10
70
";
            const string output = @"120
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"10 1
1000000000
-1000000000
1000000000
-1000000000
1000000000
-1000000000
1000000000
-1000000000
1000000000
-1000000000
";
            const string output = @"5000000000
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
