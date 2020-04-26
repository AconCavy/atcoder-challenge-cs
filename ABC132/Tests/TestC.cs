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
            var input = @"6
9 1 4 4 6 7";
            var output = @"2";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"8
9 1 14 5 5 4 4 14";
            var output = @"0";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"14
99592 10342 29105 78532 83018 11639 92015 77204 30914 21912 34519 80835 100000 1";
            var output = @"42685";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
