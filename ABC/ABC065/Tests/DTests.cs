using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"3
1 5
3 9
7 8";
            var output = @"3";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"6
8 3
4 9
12 19
18 1
13 5
7 6
";
            var output = @"8
";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
