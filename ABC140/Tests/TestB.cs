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
            var input = @"3
3 1 2
2 5 4
3 6";
            var output = @"14";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"4
2 3 4 1
13 5 8 24
45 9 15";
            var output = @"74";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"2
1 2
50 50
50";
            var output = @"150";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
