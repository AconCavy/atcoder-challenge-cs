using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ATests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"4
1 4
2 3
3 1
4 2";
            var output = @"1
1
2
2";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"7
6 4
4 3
3 5
7 1
2 7
5 2
1 6";
            var output = @"3
3
1
1
2
3
2";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"4
1 4
2 3
3 2
4 1";
            var output = @"1
1
1
1";
            Tester.InOutTest(() => Tasks.A.Solve(), input, output);
        }
    }
}
