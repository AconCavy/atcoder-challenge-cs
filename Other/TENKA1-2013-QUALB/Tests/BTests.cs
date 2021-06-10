using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"7 20
Push 2 3
Push 4 5
Top
Size
Pop 5
Top
Size";
            const string output = @"5
6
3
1
SAFE";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"1 10
Push 40 40";
            const string output = @"FULL";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"5 10
Push 1 2
Top
Pop 1
Top
Size";
            const string output = @"2
EMPTY";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"4 10
Top
Size
Push 1 1
Top";
            const string output = @"EMPTY";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
