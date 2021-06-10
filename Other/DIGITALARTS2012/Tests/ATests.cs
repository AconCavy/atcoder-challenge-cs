using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"abc aaa ababa abcba abc
2
abc
**a**";
            const string output = @"*** aaa ***** abcba ***";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"aaaa aaa aaaaaa aaaa
3
a
aa
aaa";
            const string output = @"aaaa *** aaaaaa aaaa";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"i have a pen
1
*";
            const string output = @"* have * pen";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"digital arts
1
digital*arts";
            const string output = @"digital arts";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }
    }
}
