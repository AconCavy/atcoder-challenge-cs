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
            const string input = @"7 8
40
50
30
70
70
80
80
1 2 40
1 3 50
1 4 60
2 5 90
3 4 80
4 5 110
5 6 60
6 7 50
";
            const string output = @"350
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"3 3
50
50
50
1 2 60
1 3 60
2 3 60
";
            const string output = @"150
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"5 7
80
70
60
50
40
1 3 20
1 4 70
1 5 30
2 3 30
2 4 90
3 4 40
4 5 80
";
            const string output = @"160
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
