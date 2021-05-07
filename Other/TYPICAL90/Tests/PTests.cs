using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class PTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"227
21 47 56
";
            const string output = @"5
";
            Tester.InOutTest(Tasks.P.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"9999
1 5 10
";
            const string output = @"1004
";
            Tester.InOutTest(Tasks.P.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"998244353
314159 265358 97932
";
            const string output = @"3333
";
            Tester.InOutTest(Tasks.P.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"100000000
10001 10002 10003
";
            const string output = @"9998
";
            Tester.InOutTest(Tasks.P.Solve, input, output);
        }
    }
}
