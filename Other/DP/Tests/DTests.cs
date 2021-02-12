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
            const string input = @"3 8
3 30
4 50
5 60
";
            const string output = @"90
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"5 5
1 1000000000
1 1000000000
1 1000000000
1 1000000000
1 1000000000
";
            const string output = @"5000000000
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"6 15
6 5
5 6
6 4
6 6
3 5
7 2
";
            const string output = @"17
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }
    }
}
