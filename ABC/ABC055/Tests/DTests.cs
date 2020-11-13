using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"6
ooxoox";
            var output = @"WSWSWW";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"3
oox";
            var output = @"-1";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"10
oxooxoxoox";
            var output = @"SSWWSSSWWS";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
