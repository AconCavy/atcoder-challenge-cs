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
            const string input = @"1
120000
100000
";
            const string output = @"100000
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"1
70000
100000
";
            const string output = @"-1
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"5
10000 10000 10000 10000 10000
41210 27556 29018 42919 33762
";
            const string output = @"29018
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"5
10000 10000 10000 10000 10000
30000 29999 29998 29997 29996
";
            const string output = @"29996
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
