using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class FTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"2
)
(()";
            const string output = @"Yes";
            Tester.InOutTest(() => Tasks.F.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"2
)(
()";
            const string output = @"No";
            Tester.InOutTest(() => Tasks.F.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"4
((()))
((((((
))))))
()()()";
            const string output = @"Yes";
            Tester.InOutTest(() => Tasks.F.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            const string input = @"3
(((
)
)";
            const string output = @"No";
            Tester.InOutTest(() => Tasks.F.Solve(), input, output);
        }
    }
}
