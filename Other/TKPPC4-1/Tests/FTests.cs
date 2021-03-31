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
            const string input = @"3 3
2 5 1
1 3 2
5 7 4
3 3 4
5 1 4
4 6 2
";
            const string output = @"6
";
            Tester.InOutTest(Tasks.F.Solve, input, output);
        }

        // [TestMethod, Timeout(TimeLimit)]
        // public void Test2()
        // {
        //     const string input = @"";
        //     const string output = @"";
        //     Tester.InOutTest(Tasks.F.Solve, input, output);
        // }

        // [TestMethod, Timeout(TimeLimit)]
        // public void Test3()
        // {
        //     const string input = @"";
        //     const string output = @"";
        //     Tester.InOutTest(Tasks.F.Solve, input, output);
        // }
    }
}
