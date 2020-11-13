using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            const string input = @"6
khabarovsk 20
moscow 10
kazan 50
kazan 35
moscow 60
khabarovsk 40";
            const string output = @"3
4
6
1
5
2";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            const string input = @"10
yakutsk 10
yakutsk 20
yakutsk 30
yakutsk 40
yakutsk 50
yakutsk 60
yakutsk 70
yakutsk 80
yakutsk 90
yakutsk 100";
            const string output = @"10
9
8
7
6
5
4
3
2
1";
            Tester.InOutTest(() => Tasks.B.Solve(), input, output);
        }
    }
}
