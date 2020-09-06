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
            var input = @"29
20
7
35
120";
            var output = @"215";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"101
86
119
108
57";
            var output = @"481";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"123
123
123
123
123";
            var output = @"643";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
