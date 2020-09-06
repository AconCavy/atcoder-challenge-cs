using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"2 2
2 0
0 0
-1 0
1 0";
            var output = @"2
1";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"3 4
10 10
-10 -10
3 3
1 2
2 3
3 5
3 5";
            var output = @"3
1
2";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"5 5
-100000000 -100000000
-100000000 100000000
100000000 -100000000
100000000 100000000
0 0
0 0
100000000 100000000
100000000 -100000000
-100000000 100000000
-100000000 -100000000";
            var output = @"5
4
3
2
1";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
