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
            var input = @"4
hoge
english
hoge
enigma";
            var output = @"No";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var input = @"9
basic
c
cpp
php
python
nadesico
ocaml
lua
assembly";
            var output = @"Yes";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var input = @"8
a
aa
aaa
aaaa
aaaaa
aaaaaa
aaa
aaaaaaa";
            var output = @"No";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var input = @"3
abc
arc
agc";
            var output = @"No";
            Tester.InOutTest(() => Program.Solve(), input, output);
        }
    }
}
