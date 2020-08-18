using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"5 7
1 2 2
1 4 1
2 3 7
1 5 12
3 5 2
2 5 3
3 4 5";
            var output = @"13";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"5 4
1 2 1
1 3 1
1 4 1
1 5 1";
            var output = @"-1";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"10 12
1 4 3
1 9 1
2 5 4
2 6 1
3 7 5
3 10 9
4 7 2
5 6 6
5 8 5
6 8 3
7 9 5
8 10 8";
            var output = @"11";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
