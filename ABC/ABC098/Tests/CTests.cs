using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"5
WEEWW";
            var output = @"1";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"12
WEWEWEEEWWWE";
            var output = @"4";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"8
WWWWWEEE";
            var output = @"3";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
