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
            const string input = @"3 5
4
3 30
3 40
5 60
7 80
";
            const string output = @"100
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"3 3
4
3 30
3 40
5 60
7 80
";
            const string output = @"70
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"1 5
4
3 30
3 40
5 60
7 80
";
            const string output = @"60
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"6 12
4
3 30
3 40
5 60
7 80
";
            const string output = @"210
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
