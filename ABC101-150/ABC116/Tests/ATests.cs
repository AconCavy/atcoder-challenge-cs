using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"3 4 5";
            const string output = @"6";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"5 12 13";
            const string output = @"30";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"45 28 53";
            const string output = @"630";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }
    }
}
