using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"4 3
1 2 3 4
1 3
2 3
2 4";
            const string output = @"2";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"6 5
8 6 9 1 2 1
1 3
4 2
4 3
4 6
4 6";
            const string output = @"3";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
