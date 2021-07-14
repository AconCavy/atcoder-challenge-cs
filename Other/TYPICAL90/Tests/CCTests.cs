using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CCTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"3 4
1 1
2 5
7 4
";
            const string output = @"2
";
            Tester.InOutTest(Tasks.CC.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"2 123
4 5
678 901
";
            const string output = @"1
";
            Tester.InOutTest(Tasks.CC.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"7 10
20 20
20 20
20 30
20 40
30 20
30 30
40 20
";
            const string output = @"5
";
            Tester.InOutTest(Tasks.CC.Solve, input, output);
        }
    }
}
