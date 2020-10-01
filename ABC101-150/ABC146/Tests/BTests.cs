using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"2
ABCXYZ";
            const string output = @"CDEZAB";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"0
ABCXYZ";
            const string output = @"ABCXYZ";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"13
ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string output = @"NOPQRSTUVWXYZABCDEFGHIJKLM";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
