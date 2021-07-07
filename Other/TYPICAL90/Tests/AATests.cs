using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class AATests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"5
e869120
atcoder
e869120
square1001
square1001
";
            const string output = @"1
2
4
";
            Tester.InOutTest(Tasks.AA.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"4
taro
hanako
yuka
takashi
";
            const string output = @"1
2
3
4
";
            Tester.InOutTest(Tasks.AA.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"10
square869120
square869120
square869120
square869120
square869120
square869120
square869120
square869120
square869120
square869120
";
            const string output = @"1
";
            Tester.InOutTest(Tasks.AA.Solve, input, output);
        }
    }
}
