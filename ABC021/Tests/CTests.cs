using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"7
1 7
8
1 2
1 3
4 2
4 3
4 5
4 6
7 5
7 6";
            var output = @"4";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"7
1 7
9
1 2
1 3
4 2
4 3
4 5
4 6
7 5
7 6
4 7";
            var output = @"2";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"7
4 1
9
1 2
1 3
4 2
4 3
4 5
4 6
7 5
7 6
4 7";
            var output = @"2";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
