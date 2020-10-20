using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"2 2
2 1 2
1 2
0 1";
            const string output = @"1";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"2 3
2 1 2
1 1
1 2
0 0 1";
            const string output = @"0";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"5 2
3 1 2 5
2 2 3
1 0";
            const string output = @"8";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
