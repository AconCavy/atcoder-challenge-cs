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
2 3 1";
            const string output = @"3 1 2";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"5
1 2 3 4 5";
            const string output = @"1 2 3 4 5";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"8
8 2 7 3 4 5 6 1";
            const string output = @"8 2 4 5 6 7 3 1";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
