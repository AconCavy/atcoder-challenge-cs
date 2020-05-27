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
            var input = @"5 3
-30 -10 10 20 50";
            var output = @"40";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"3 2
10 20 30";
            var output = @"20";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"1 1
0";
            var output = @"0";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = @"8 5
-9 -7 -4 -3 1 2 3 4";
            var output = @"10";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod5()
        {
            var input = @"8 8
-9 -7 -4 -3 1 2 3 4";
            var output = @"17";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
