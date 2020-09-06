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
            var input = @"2
10 30";
            var output = @"7.5";
            Tester.InOutTest(() => Program.Solve(), input, output, -6);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"3
200 200 200";
            var output = @"66.66666666666667";
            Tester.InOutTest(() => Program.Solve(), input, output, -6);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"1
1000";
            var output = @"1000";
            Tester.InOutTest(() => Program.Solve(), input, output, -6);
        }
    }
}
