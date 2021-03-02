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
            const string input = @"5
1 3 3 3 3
3 3 2 2 2
";
            const string output = @"4
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"5
1 1 1 2 2
3 2 1 1 1
";
            const string output = @"0
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"10
1 3776 3776 8848 8848 8848 8848 8848 8848 8848
8848 8848 8848 8848 8848 8848 8848 8848 3776 5
";
            const string output = @"884111967
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"1
17
17
";
            const string output = @"1
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
