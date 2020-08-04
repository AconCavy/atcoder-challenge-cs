using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"3
10 40 70
20 50 80
30 60 90";
            var output = @"210";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"1
100 10 1";
            var output = @"100";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"7
6 7 8
8 8 3
2 5 2
7 8 6
4 6 8
2 3 4
7 5 1";
            var output = @"46";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
