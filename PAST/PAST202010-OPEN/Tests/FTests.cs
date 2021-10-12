using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class FTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"6 2
abcde
caac
abcde
caac
abc
caac
";
            const string output = @"abcde
";
            Tester.InOutTest(Tasks.F.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"9 3
a
a
bb
bb
a
ccc
bb
ccc
dddd
";
            const string output = @"ccc
";
            Tester.InOutTest(Tasks.F.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"7 2
caac
abcde
caac
abc
abcde
caac
abc
";
            const string output = @"AMBIGUOUS
";
            Tester.InOutTest(Tasks.F.Solve, input, output);
        }
    }
}
