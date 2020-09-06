using Microsoft.VisualStudio.TestTools.UnitTesting;
using B;

namespace Tests
{
    [TestClass]
    public class TestB
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"6
AC
TLE
AC
AC
WA
TLE";
            var output = @"AC x 3
WA x 1
TLE x 2
RE x 0";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"10
AC
AC
AC
AC
AC
AC
AC
AC
AC
AC";
            var output = @"AC x 10
WA x 0
TLE x 0
RE x 0";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
