using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"5
1 2
1 3
1 4
4 5
3
2 3
2 5
2 4";
            var output = @"3
4
3";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"6
1 2
2 3
3 4
4 5
5 6
4
1 3
1 4
1 5
1 6";
            var output = @"3
4
5
6";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"7
3 1
2 1
2 4
2 5
3 6
3 7
5
4 5
1 6
5 6
4 7
5 3";
            var output = @"3
3
5
5
4";
            Tester.InOutTest(() => Tasks.D.Solve(), input, output);
        }
    }
}
