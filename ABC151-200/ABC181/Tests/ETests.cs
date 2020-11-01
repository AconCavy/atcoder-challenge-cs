using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ETests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"5 3
1 2 3 4 7
1 3 8";
            const string output = @"3";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"7 7
31 60 84 23 16 13 32
96 80 73 76 87 57 29";
            const string output = @"34";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"15 10
554 525 541 814 661 279 668 360 382 175 833 783 688 793 736
496 732 455 306 189 207 976 73 567 759";
            const string output = @"239";
            Tester.InOutTest(() => Tasks.E.Solve(), input, output);
        }
    }
}
