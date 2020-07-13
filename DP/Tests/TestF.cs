using Microsoft.VisualStudio.TestTools.UnitTesting;
using F;

namespace Tests
{
    [TestClass]
    public class TestF
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"axyb
abyxb";
            var output = @"axb";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"aa
xayaz";
            var output = @"aa";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"a
z";
            var output = @"
";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = @"abracadabra
avadakedavra";
            var output = @"aaadara";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
