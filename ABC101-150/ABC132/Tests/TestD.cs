using Microsoft.VisualStudio.TestTools.UnitTesting;
using D;

namespace Tests
{
    [TestClass]
    public class TestD
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"5 3";
            var output = @"3
6
1
";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"2000 3";
            var output = @"1998
3990006
327341989";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
