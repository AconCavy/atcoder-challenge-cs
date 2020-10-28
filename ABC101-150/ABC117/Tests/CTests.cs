using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"2 5
10 12 1 2 14";
            const string output = @"5";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"3 7
-10 -3 0 9 -100 2 17";
            const string output = @"19";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"100 1
-100000";
            const string output = @"0";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
