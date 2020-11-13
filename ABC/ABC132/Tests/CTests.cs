using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"6
9 1 4 4 6 7";
            const string output = @"2";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"8
9 1 14 5 5 4 4 14";
            const string output = @"0";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"14
99592 10342 29105 78532 83018 11639 92015 77204 30914 21912 34519 80835 100000 1";
            const string output = @"42685";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
