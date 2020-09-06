using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"3 2
1 2
2 3";
            var output = @"1
0
1";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"3 3
1 2
1 3
2 3";
            var output = @"0
0
0";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"8 12
1 6
1 7
1 8
2 5
2 6
3 5
3 6
4 5
4 8
5 6
5 7
7 8";
            var output = @"4
4
4
5
2
3
4
2";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
