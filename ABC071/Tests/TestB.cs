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
            var input = @"atcoderregularcontest";
            var output = @"b";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"abcdefghijklmnopqrstuvwxyz";
            var output = @"None";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"fajsonlslfepbjtsaayxbymeskptcumtwrmkkinjxnnucagfrg";
            var output = @"d";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
