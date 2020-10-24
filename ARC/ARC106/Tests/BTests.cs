using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"3 2
1 2 3
2 2 2
1 2
2 3";
            const string output = @"Yes";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"1 0
5
5";
            const string output = @"Yes";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"2 1
1 1
2 1
1 2";
            const string output = @"No";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
