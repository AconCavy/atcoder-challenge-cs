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
            const string input = @"5 3
tokyo kanda akiba okachi ueno
tokyo akiba ueno
";
            const string output = @"Yes
No
Yes
No
Yes
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"7 7
a t c o d e r
a t c o d e r
";
            const string output = @"Yes
Yes
Yes
Yes
Yes
Yes
Yes
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
