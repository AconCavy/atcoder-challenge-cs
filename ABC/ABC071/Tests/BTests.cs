using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"atcoderregularcontest";
            var output = @"b";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"abcdefghijklmnopqrstuvwxyz";
            var output = @"None";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"fajsonlslfepbjtsaayxbymeskptcumtwrmkkinjxnnucagfrg";
            var output = @"d";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
