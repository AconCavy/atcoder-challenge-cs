using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BITests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"6
1 2
1 1
2 3
3 1
3 2
3 3
";
            const string output = @"1
2
3
";
            Tester.InOutTest(Tasks.BI.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"6
2 1
3 1
2 2
3 1
2 3
3 1
";
            const string output = @"1
1
1
";
            Tester.InOutTest(Tasks.BI.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"6
1 1000000000
2 200000000
1 30000000
2 4000000
1 500000
3 3
";
            const string output = @"1000000000
";
            Tester.InOutTest(Tasks.BI.Solve, input, output);
        }
    }
}
