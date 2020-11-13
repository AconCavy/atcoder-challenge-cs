using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ETests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"2 3
7 9";
            var output = @"4";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"3 0
3 4 5";
            var output = @"5";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"10 10
158260522 877914575 602436426 24979445 861648772 623690081 433933447 476190629 262703497 211047202";
            var output = @"292638192";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }
    }
}
