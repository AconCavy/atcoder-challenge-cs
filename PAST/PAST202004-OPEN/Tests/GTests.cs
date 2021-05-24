using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class GTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"6
1 a 5
2 3
1 t 8
1 c 10
2 21
2 4
";
            const string output = @"9
168
0
";
            Tester.InOutTest(Tasks.G.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"4
1 x 5
1 y 8
2 7
1 z 8
";
            const string output = @"29
";
            Tester.InOutTest(Tasks.G.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"3
1 p 3
1 q 100000
2 100000
";
            const string output = @"9999400018
";
            Tester.InOutTest(Tasks.G.Solve, input, output);
        }
    }
}
