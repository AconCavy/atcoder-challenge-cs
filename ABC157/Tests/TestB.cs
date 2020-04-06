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
            var input = "84 97 66\n79 89 11\n61 59 7\n7\n89\n7\n87\n79\n24\n84\n30\n";
            var output = "Yes\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = "41 7 46\n26 89 2\n78 92 8\n5\n6\n45\n16\n57\n17\n";
            var output = "No\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = "60 88 34\n92 41 43\n65 73 48\n10\n60\n43\n88\n11\n48\n73\n65\n41\n92\n34\n";
            var output = "Yes\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = "1 2 3\n4 5 6\n7 8 9\n3\n1\n2\n3\n";
            var output = "Yes\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod5()
        {
            var input = "1 2 3\n4 5 6\n7 8 9\n3\n1\n4\n7\n";
            var output = "Yes\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod6()
        {
            var input = "1 2 3\n4 5 6\n7 8 9\n3\n1\n5\n9\n";
            var output = "Yes\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod7()
        {
            var input = "1 2 3\n4 5 6\n7 8 9\n3\n3\n5\n7\n";
            var output = "Yes\n";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
