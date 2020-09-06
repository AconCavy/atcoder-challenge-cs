using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"WBWBWWBWBWBWWBWBWWBW";
            var output = @"Do";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"WWBWBWWBWBWBWWBWBWWB";
            var output = @"Si";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
