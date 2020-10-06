using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"RUDLUDR";
            const string output = @"Yes";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"DULL";
            const string output = @"No";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"UUUUUUUUUUUUUUU";
            const string output = @"Yes";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            const string input = @"ULURU";
            const string output = @"No";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod5()
        {
            const string input = @"RDULULDURURLRDULRLR";
            const string output = @"Yes";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
