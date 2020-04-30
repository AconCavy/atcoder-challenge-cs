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
            var input = @"6
khabarovsk 20
moscow 10
kazan 50
kazan 35
moscow 60
khabarovsk 40";
            var output = @"3
4
6
1
5
2";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"10
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
            var output = @"10
9
8
7
6
5
4
3
2
1";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
