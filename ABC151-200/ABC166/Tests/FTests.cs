using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class FTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"2 1 3 0
AB
AC";
            const string output = @"Yes
A
C";
            Tester.InOutTest(() => Tasks.F.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"3 1 0 0
AB
BC
AB";
            const string output = @"No";
            Tester.InOutTest(() => Tasks.F.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            const string input = @"1 0 9 0
AC";
            const string output = @"No";
            Tester.InOutTest(() => Tasks.F.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            const string input = @"8 6 9 1
AC
BC
AB
BC
AC
BC
AB
AB";
            const string output = @"Yes
C
C
A
C
C
C
A
B";
            Tester.InOutTest(() => Tasks.F.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod5()
        {
            const string input = @"5 0 0 0
AB
BC
AB
AC
AC";
            const string output = @"No";
            Tester.InOutTest(() => Tasks.F.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod6()
        {
            const string input = @"5 0 1 1
BC
AB
AC
AB
AC";
            const string output = @"Yes
B
A
C
A
C";
            Tester.InOutTest(() => Tasks.F.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod7()
        {
            const string input = @"5 1 1 0
AB
BC
AC
BC
AB";
            const string output = @"Yes
B
C
A
C
B";
            Tester.InOutTest(() => Tasks.F.Solve(), input, output);
        }
    }
}
