using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"5 3
10
15
11
14
12";
            const string output = @"2";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"5 3
5
7
5
7
7";
            const string output = @"0";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
