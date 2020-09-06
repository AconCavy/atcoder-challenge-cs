using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"3 4
1 3 5 17
2 4 2 3
1 3 2 9";
            var output = @"Found";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"5 3
89 62 15
44 36 17
4 24 24
25 98 99
66 33 57";
            var output = @"Nothing";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
