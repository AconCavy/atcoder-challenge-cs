using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"5
1 3
2 2
3 2
4 1
4 3";
            var output = @"1 2 7";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"9
2 0
1 1
3 1
1 2
5 2
0 3
4 3
2 4
4 4";
            var output = @"27 14 43";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
