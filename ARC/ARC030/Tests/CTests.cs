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
            const string input = @"4 4 3
a b b a
1 2
2 3
3 1
4 3
";
            const string output = @"aab
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"5 4 4
d a b c a
1 2
2 3
3 4
2 5
";
            const string output = @"dabc
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"5 4 3
d a b c a
1 2
2 3
3 4
2 5
";
            const string output = @"abc
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"3 0 2
a b c
";
            const string output = @"-1
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
