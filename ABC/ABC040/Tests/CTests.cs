using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"4
100 150 130 120";
            var output = @"40";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"4
100 125 80 110";
            var output = @"40";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"9
314 159 265 358 979 323 846 264 338";
            var output = @"310";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
