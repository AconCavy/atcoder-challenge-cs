using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"1 2 3";
            const string output = @"3 1 2";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"100 100 100";
            const string output = @"100 100 100";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"41 59 31";
            const string output = @"31 41 59";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }
    }
}
