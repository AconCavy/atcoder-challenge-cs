using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class FTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void TestMethod1()
        {
            const string input = @"5 17
2 3 5 7 11
";
            const string output = @"17
";
            Tester.InOutTest(Tasks.F.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void TestMethod2()
        {
            const string input = @"6 100
1 2 7 5 8 10
";
            const string output = @"33
";
            Tester.InOutTest(Tasks.F.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void TestMethod3()
        {
            const string input = @"6 100
101 102 103 104 105 106
";
            const string output = @"0
";
            Tester.InOutTest(Tasks.F.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void TestMethod4()
        {
            const string input = @"7 273599681
6706927 91566569 89131517 71069699 75200339 98298649 92857057
";
            const string output = @"273555143
";
            Tester.InOutTest(Tasks.F.Solve, input, output);
        }
    }
}
