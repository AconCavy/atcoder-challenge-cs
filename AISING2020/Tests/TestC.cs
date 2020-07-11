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
            var input = @"20";
            var output = @"0
0
0
0
0
1
0
0
0
0
3
0
0
0
0
0
3
3
0
0";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
