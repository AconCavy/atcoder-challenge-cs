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
3 1 5 4 2
";
            const string output = @"3,1,5,4,2
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"6
1 2 3 4 5 6
";
            const string output = @"1,2,3,4,5,6
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"7
7 6 5 4 3 2 1
";
            const string output = @"7,6,5,4,3,2,1
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
