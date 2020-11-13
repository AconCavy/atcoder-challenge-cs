using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"10
ZABCDBABCQ";
            const string output = @"2";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"19
THREEONEFOURONEFIVE";
            const string output = @"0";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"33
ABCCABCBABCCABACBCBBABCBCBCBCABCB";
            const string output = @"5";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
