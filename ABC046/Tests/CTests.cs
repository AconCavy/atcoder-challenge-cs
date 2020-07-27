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
2 3
1 1
3 2";
            var output = @"10";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"4
1 1
1 1
1 5
1 100";
            var output = @"101";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"5
3 10
48 17
31 199
231 23
3 2";
            var output = @"6930";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
