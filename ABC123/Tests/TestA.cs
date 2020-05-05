using Microsoft.VisualStudio.TestTools.UnitTesting;
using A;

namespace Tests
{
    [TestClass]
    public class TestA
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"1
2
4
8
9
15";
            var output = @"Yay!";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"15
18
26
35
36
18";
            var output = @":(";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
