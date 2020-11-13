using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"2
3 5 2
4 5";
            const string output = @"9";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"3
5 6 3 8
5 100 8";
            const string output = @"22";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"2
100 1 1
1 100";
            const string output = @"3";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
