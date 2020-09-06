using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class FTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"axyb
abyxb";
            var output = @"axb";
            Tester.InOutTest(() => Tasks.F.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"aa
xayaz";
            var output = @"aa";
            Tester.InOutTest(() => Tasks.F.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"a
z";
            var output = @"
";
            Tester.InOutTest(() => Tasks.F.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = @"abracadabra
avadakedavra";
            var output = @"aaadara";
            Tester.InOutTest(() => Tasks.F.Solve(), input, output);
        }
    }
}
