using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"3
1
2 1
1
1 1
1
2 0";
            const string output = @"2";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"3
2
2 1
3 0
2
3 1
1 0
2
1 1
2 0";
            const string output = @"0";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"2
1
2 0
1
1 0";
            const string output = @"1";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
