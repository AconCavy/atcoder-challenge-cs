using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"3 1
1 2";
            const string output = @"1";
            Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        }

        // [TestMethod]
        // public void TestMethod2()
        // {
        //     const string input = @"";
        //     const string output = @"";
        //     Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        // }

        // [TestMethod]
        // public void TestMethod3()
        // {
        //     const string input = @"";
        //     const string output = @"";
        //     Tester.InOutTest(() => Tasks.C.Solve(), input, output);
        // }
    }
}
