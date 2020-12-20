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
            const string input = @"3
123 2
4 2
56 1
1000000007";
            const string output = @"231234449";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"1
123 3
1000000007";
            const string output = @"123123123";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"1
123456789 10000
1000000007";
            const string output = @"372735614";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"4
810143056 100000000
81671422 99999999
1639053 99999998
1657560 99999997
1000000007";
            const string output = @"476685993";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test5()
        {
            const string input = @"3
2 3
3 2
5 3
99";
            const string output = @"36";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
