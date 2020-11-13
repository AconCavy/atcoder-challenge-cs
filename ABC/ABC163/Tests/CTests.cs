using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"5
1 1 2 2";
            const string output = @"2
2
0
0
0";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"10
1 1 1 1 1 1 1 1 1";
            const string output = @"9
0
0
0
0
0
0
0
0
0";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"7
1 2 3 4 5 6";
            const string output = @"1
1
1
1
1
1
0";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
