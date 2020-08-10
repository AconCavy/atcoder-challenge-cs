using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"15 0";
            var output = @"90";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output, -4);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"3 17";
            var output = @"3.5";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output, -4);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"0 0";
            var output = @"0";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output, -4);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = @"6 0";
            var output = @"180";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output, -4);
        }

        [TestMethod]
        public void TestMethod5()
        {
            var input = @"23 59";
            var output = @"5.5000";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output, -4);
        }

        [TestMethod]
        public void TestMethod6()
        {
            var input = @"13 0";
            var output = @"30";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
