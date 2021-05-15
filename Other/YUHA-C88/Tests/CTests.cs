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
            const string input = @"1
ARTHUR
ARTHUR is a good venturer.
";
            const string output = @"ARTHUR
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"2
CAIN
COOKIE
COOKIE is a good venturer.
CAIN is a good venturer.
";
            const string output = @"CAIN
COOKIE
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"2
KONAN
TONNELAT
TONNELAT is a bad venturer.
KONAN is a bad venturer.
";
            const string output = @"KONAN
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"2
PAOLO
LAND
LAND is a good venturer.
PAOLO is a bad venturer.";
            const string output = @"No answers";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
