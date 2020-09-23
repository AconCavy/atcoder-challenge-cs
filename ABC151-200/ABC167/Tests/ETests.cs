using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ETests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"3 2 1";
            const string output = @"6";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"100 100 0";
            const string output = @"73074801";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"60522 114575 7559";
            const string output = @"479519525";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }
    }
}
