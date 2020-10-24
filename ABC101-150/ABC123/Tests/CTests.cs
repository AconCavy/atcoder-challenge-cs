using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"5
3
2
4
3
5";
            const string output = @"7";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"10
123
123
123
123
123";
            const string output = @"5";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"10000000007
2
3
5
7
11";
            const string output = @"5000000008";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
