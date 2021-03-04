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
            const string input = @"3 4
aabb
aabb
aacc
";
            const string output = @"Yes
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"2 2
aa
bb
";
            const string output = @"No
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"5 1
t
w
e
e
t
";
            const string output = @"Yes
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"2 5
abxba
abyba
";
            const string output = @"No
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test5()
        {
            const string input = @"1 1
z
";
            const string output = @"Yes
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
