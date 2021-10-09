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
GCP
PPP
CCC
PPC
";
            const string output = @"3
1
2
4
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"2 2
GC
PG
CG
PP
";
            const string output = @"1
2
3
4
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
