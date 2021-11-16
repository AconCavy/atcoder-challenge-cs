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
            const string input = @"9
ixixixixi
";
            const string output = @"...x...xi
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"6
auxuxa
";
            const string output = @"a...xa
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"15
gxgaxixuxexoxxx
";
            const string output = @"gxgaxixuxexoxxx
";
            Tester.InOutTest(Tasks.D.Solve, input, output);
        }
    }
}
