using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ETests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"100
1";
            var output = @"19";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"25
2";
            var output = @"14";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"314159
2";
            var output = @"937";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = @"9999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999
3";
            var output = @"117879300";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }
    }
}
