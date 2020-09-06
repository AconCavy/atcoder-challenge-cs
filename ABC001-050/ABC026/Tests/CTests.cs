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
1
1
1
1";
            var output = @"3";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"7
1
1
2
2
3
3";
            var output = @"7";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"6
1
2
3
3
2";
            var output = @"11";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = @"10
1
2
3
4
5
6
7
8
9";
            var output = @"1023";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
