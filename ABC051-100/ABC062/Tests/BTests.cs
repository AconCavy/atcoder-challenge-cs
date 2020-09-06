using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
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
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"1 1
z";
            var output = @"###
#z#
###";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
