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
            const string input = @"5 3 3 5
R 1
G 1
B 1
RGBRR";
            const string output = @"13";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"3 3 3 5
R 1
G 3
B 2
RBR";
            const string output = @"5";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"8 3 5 3
R 1
G 1
B 1
RRGRRBRR";
            const string output = @"31";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"8 3 5 3
R 1
G 100
B 1
RRGRRBRR";
            const string output = @"126";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
