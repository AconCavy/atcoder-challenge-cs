using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ETests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"3 5 4
11100
10001
00111";
            var output = @"2";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"3 5 8
11100
10001
00111";
            var output = @"0";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"4 10 4
1110010010
1000101110
0011101001
1101000111";
            var output = @"3";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }
    }
}
