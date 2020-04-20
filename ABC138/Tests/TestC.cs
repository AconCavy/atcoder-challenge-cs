using Microsoft.VisualStudio.TestTools.UnitTesting;
using C;

namespace Tests
{
    [TestClass]
    public class TestC
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"2
3 4";
            var output = @"3.5";
            Tester.InOutTest(() => Program.Solve(), input, output, -5);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"3
500 300 200";
            var output = @"375";
            Tester.InOutTest(() => Program.Solve(), input, output, -5);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"5
138 138 138 138 138";
            var output = @"138";
            Tester.InOutTest(() => Program.Solve(), input, output, -5);
        }
    }
}
