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
2
1 3
1
3";
            const string output = @"1";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"3 3
1
3
1
3
1
3";
            const string output = @"2";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
