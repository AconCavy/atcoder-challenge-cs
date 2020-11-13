using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"2 3
1 32
2 63
1 12";
            const string output = @"000001000002
000002000001
000001000001";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"2 3
2 55
2 77
2 99";
            const string output = @"000002000001
000002000002
000002000003";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
