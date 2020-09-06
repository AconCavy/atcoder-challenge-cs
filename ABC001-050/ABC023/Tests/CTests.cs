using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"3 5 3
5
1 2
2 1
2 5
3 2
3 5";
            var output = @"5";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"7 3 1
4
3 2
3 3
4 2
4 3";
            var output = @"0";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"5 5 2
5
1 1
2 2
3 3
4 4
5 5";
            var output = @"20";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
