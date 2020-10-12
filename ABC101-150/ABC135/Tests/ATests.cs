using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"2 16";
            const string output = @"9";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"0 3";
            const string output = @"IMPOSSIBLE";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"998244353 99824435";
            const string output = @"549034394";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }
    }
}
