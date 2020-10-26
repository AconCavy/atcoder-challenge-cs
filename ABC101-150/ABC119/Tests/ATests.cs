using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"2019/04/30";
            const string output = @"Heisei";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"2019/11/01";
            const string output = @"TBD";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }
    }
}
