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
10
15
11
14
12";
            var output = @"2";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"5 3
5
7
5
7
7";
            var output = @"0";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
