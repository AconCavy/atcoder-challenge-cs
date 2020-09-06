using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"5 4
1 4
2 5
3 3
1 5";
            var output = @"01010";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"20 8
1 8
4 13
8 8
3 18
5 20
19 20
2 7
4 9";
            var output = @"10110000011110000000";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
