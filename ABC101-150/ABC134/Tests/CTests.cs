using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"3
1
4
3";
            const string output = @"4
3
4";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"2
5
5";
            const string output = @"5
5";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
