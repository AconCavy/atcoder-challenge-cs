using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"3 3
1 2
1 3
2 3";
            var output = @"2";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"7 7
1 3
2 7
3 4
4 5
4 6
5 6
6 7";
            var output = @"1";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
