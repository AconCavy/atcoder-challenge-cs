using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"UL?
1";
            var output = @"3";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"UD?
1";
            var output = @"1";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"UUUU?DDR?LLLL
1";
            var output = @"7";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = @"UULL?
2";
            var output = @"3";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
