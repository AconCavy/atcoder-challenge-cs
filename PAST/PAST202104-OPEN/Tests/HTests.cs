using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class HTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"6 3 2 10
15 1
25 0
20 0
10 1
5 1
20 0
";
            const string output = @"45
";
            Tester.InOutTest(Tasks.H.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"5 2 5 40
120 0
1 1
90 0
10 0
50 0
";
            const string output = @"51
";
            Tester.InOutTest(Tasks.H.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"16 9 1 631593942
758234071 1
872232933 0
928146137 0
141777768 0
339097211 1
590423762 1
656886697 1
164443392 0
181259343 0
509224290 0
973377384 0
934014075 1
167877698 1
549037938 0
94228809 1
898548470 0
";
            const string output = @"4841818525
";
            Tester.InOutTest(Tasks.H.Solve, input, output);
        }
    }
}
