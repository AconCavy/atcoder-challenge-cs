using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"2 7";
            const string output = @"4";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"1 1";
            const string output = @"0";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"50 4321098765432109";
            const string output = @"2160549382716056";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
