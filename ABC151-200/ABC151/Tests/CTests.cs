using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"2 5
1 WA
1 AC
2 WA
2 AC
2 WA";
            var output = @"2 2";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"100000 3
7777 AC
7777 AC
7777 AC";
            var output = @"1 0";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"6 0";
            var output = @"0 0";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
