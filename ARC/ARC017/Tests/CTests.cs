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
            const string input = @"5 5
1
1
2
3
4";
            const string output = @"4";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test2()
        {
            const string input = @"8 21
10
4
2
30
22
20
8
14";
            const string output = @"0";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test3()
        {
            const string input = @"20 100000000
35576749
38866484
6624951
39706038
11133516
25490903
14701702
17888322
14423251
32111678
24509097
43375049
35298298
21158709
30489274
37977301
19510726
28841291
10293962
12022699";
            const string output = @"45";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }

        [TestMethod, Timeout(TimeLimit)]
        public void Test4()
        {
            const string input = @"16 8
1
1
1
1
1
1
1
1
1
1
1
1
1
1
1
1";
            const string output = @"12870";
            Tester.InOutTest(Tasks.C.Solve, input, output);
        }
    }
}
