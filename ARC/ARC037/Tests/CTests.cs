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
            const string input = @"2 3
2 3
3 5
";
            const string output = @"10
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"3 7
1 2 1
2 1 2
";
            const string output = @"2
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"4 8
701687787 500872619 516391519 599949380
458299111 633119409 377269575 717229869
";
            const string output = @"317112176525562171
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
