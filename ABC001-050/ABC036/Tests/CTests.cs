using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"5
3
3
1
6
1";
            var output = @"1
1
0
2
0";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
