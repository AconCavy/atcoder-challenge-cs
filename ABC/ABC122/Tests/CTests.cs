using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"8 3
ACACTACG
3 7
2 3
1 8";
            const string output = @"2
0
3";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
