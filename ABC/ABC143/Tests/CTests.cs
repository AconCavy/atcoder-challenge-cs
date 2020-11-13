using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"10
aabbbbaaca";
            const string output = @"5";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"5
aaaaa";
            const string output = @"1";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"20
xxzaffeeeeddfkkkkllq";
            const string output = @"10";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }
    }
}
