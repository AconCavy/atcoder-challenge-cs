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
            var input = @"3
cbaa
daacc
acacac";
            var output = @"aac";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"3
a
aa
b";
            var output = @"
";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
