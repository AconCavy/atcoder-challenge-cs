using Microsoft.VisualStudio.TestTools.UnitTesting;
using D;

namespace Tests
{
    [TestClass]
    public class TestD
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"8
1 4
10 5
3 3
4 11
8 9
22 40
8 36
314159265 358979323";
            var output = @"1
12
4
11
14
57
31
671644785
";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
