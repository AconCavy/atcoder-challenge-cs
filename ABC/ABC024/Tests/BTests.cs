using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"5 10
20
100
105
217
314";
            var output = @"45";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"10 10
1
2
3
4
5
6
7
8
9
10";
            var output = @"19";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"10 100000
3
31
314
3141
31415
314159
400000
410000
500000
777777";
            var output = @"517253";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
