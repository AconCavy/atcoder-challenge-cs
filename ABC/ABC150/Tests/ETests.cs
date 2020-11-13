using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ETests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"1
1000000000";
            const string output = @"999999993";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"2
5 8";
            const string output = @"124";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"5
52 67 72 25 79";
            const string output = @"269312";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }
    }
}
