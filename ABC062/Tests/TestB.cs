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
            var input = @"2 3
abc
arc";
            var output = @"#####
#abc#
#arc#
#####";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"1 1
z";
            var output = @"###
#z#
###";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
