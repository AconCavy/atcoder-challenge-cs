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
            var input = @"5 100 90 80
98
40
30
21
80";
            var output = @"23";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"8 100 90 80
100
100
90
90
90
80
80
80";
            var output = @"0";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"8 1000 800 100
300
333
400
444
500
555
600
666";
            var output = @"243";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
