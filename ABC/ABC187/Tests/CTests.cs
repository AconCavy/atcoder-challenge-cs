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
            const string input = @"6
a
!a
b
!c
d
!d
";
            const string output = @"a
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"10
red
red
red
!orange
yellow
!blue
cyan
!green
brown
!gray
";
            const string output = @"satisfiable
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
