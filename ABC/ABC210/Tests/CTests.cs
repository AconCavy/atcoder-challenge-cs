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
            const string input = @"7 3
1 2 1 2 3 3 1
";
            const string output = @"3
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"5 5
4 4 4 4 4
";
            const string output = @"1
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"10 6
304621362 506696497 304621362 506696497 834022578 304621362 414720753 304621362 304621362 414720753
";
            const string output = @"4
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
