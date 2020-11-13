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
3 5 -1";
            var output = @"12
8
10";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"5
1 1 1 2 0";
            var output = @"4
4
4
2
4";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"6
-679 -2409 -3258 3095 -3291 -4462";
            var output = @"21630
21630
19932
8924
21630
19288";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
