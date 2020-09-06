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
            var input = @"8 3
ACACTACG
3 7
2 3
1 8";
            var output = @"2
0
3";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
