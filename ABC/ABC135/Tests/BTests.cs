using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"5
5 2 3 4 1";
            const string output = @"YES";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"5
2 4 3 5 1";
            const string output = @"NO";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"7
1 2 3 4 5 6 7";
            const string output = @"YES";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
