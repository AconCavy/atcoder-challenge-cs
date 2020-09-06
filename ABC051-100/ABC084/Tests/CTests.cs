using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"3
6 5 1
1 10 1";
            var output = @"12
11
0";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"4
12 24 6
52 16 4
99 2 2";
            var output = @"187
167
101
0";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"4
12 13 1
44 17 17
66 4096 64";
            var output = @"4162
4162
4162
0";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
