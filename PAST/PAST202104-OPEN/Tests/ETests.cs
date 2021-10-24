using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ETests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"11
LLRLRCDEFBA
";
            const string output = @"1
5
2
ERROR
3
4
";
            Tester.InOutTest(Tasks.E.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"36
RLLDBBDDLCLDFRLRRLRRFLRDRLALLELCAARF
";
            const string output = @"1
2
ERROR
3
ERROR
ERROR
9
ERROR
17
23
26
20
28
31
29
19
";
            Tester.InOutTest(Tasks.E.Solve, input, output);
        }
    }
}
