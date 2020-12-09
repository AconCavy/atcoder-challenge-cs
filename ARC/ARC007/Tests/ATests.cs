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
            const string input = @"a
abcdefgabcdefg";
            const string output = @"bcdefgbcdefg";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"g
aassddffgg";
            const string output = @"aassddff";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"a
aaaaa";
            const string output = @"
";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"l
qwertyuiopasdfghjklzxcvbnm";
            const string output = @"qwertyuiopasdfghjkzxcvbnm";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test5()
        {
            const string input = @"d
qwsdtgcszddddsdfgvbbnj";
            const string output = @"qwstgcszsfgvbbnj";
            Tester.InOutTest(Tasks.A.Solve, input, output);
        }
    }
}
