using Microsoft.VisualStudio.TestTools.UnitTesting;
using B;

namespace Tests
{
    [TestClass]
    public class TestB
    {
        [TestMethod]
        public void TestMethod1()
        {
            var input = @"3 2 10 20
8 15 13
16 22";
            var output = @"No War";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"4 2 -48 -1
-20 -35 -91 -23
-22 66";
            var output = @"War";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"5 3 6 8
-10 3 1 5 -100
100 6 14";
            var output = @"War";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
