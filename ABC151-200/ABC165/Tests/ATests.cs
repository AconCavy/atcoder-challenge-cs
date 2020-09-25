using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"7
500 600";
            const string output = @"OK";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"4
5 7";
            const string output = @"NG";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"1
11 11";
            const string output = @"OK";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }
    }
}
