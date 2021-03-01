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
            const string input = @"10 2 3
abccabaabb
";
            const string output = @"Yes
Yes
No
No
Yes
Yes
Yes
No
No
No
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"12 5 2
cabbabaacaba
";
            const string output = @"No
Yes
Yes
Yes
Yes
No
Yes
Yes
No
Yes
No
No
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"5 2 2
ccccc
";
            const string output = @"No
No
No
No
No
";
            Tester.InOutTest(Tasks.B.Solve, input, output);
        }
    }
}
