using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CTests
    {
        const int TimeLimit = 2000;
        const double RelativeError = 1e-9;

        [TestMethod, Timeout(TimeLimit)]
        public void Test1()
        {
            const string input = @"3 4
ABC
A L
B L
B R
A R
";
            const string output = @"2
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"8 3
AABCBDBA
A L
B R
A R
";
            const string output = @"5
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"10 15
SNCZWRCEWB
B R
R R
E R
W R
Z L
S R
Q L
W L
B R
C L
A L
N L
E R
Z L
S L
";
            const string output = @"3
";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
