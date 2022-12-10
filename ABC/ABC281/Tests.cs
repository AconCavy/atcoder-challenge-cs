using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"3
",
            @"3
2
1
0
")]
        [TestCase(
            @"22
",
            @"22
21
20
19
18
17
16
15
14
13
12
11
10
9
8
7
6
5
4
3
2
1
0
")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"Q142857Z
",
            @"Yes
")]
        [TestCase(
            @"AB912278C
",
            @"No
")]
        [TestCase(
            @"X900000
",
            @"No
")]
        [TestCase(
            @"K012345K
",
            @"No
")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3 600
180 240 120
",
            @"1 60
")]
        [TestCase(
            @"3 281
94 94 94
",
            @"3 93
")]
        [TestCase(
            @"10 5678912340
1000000000 1000000000 1000000000 1000000000 1000000000 1000000000 1000000000 1000000000 1000000000 1000000000
",
            @"6 678912340
")]
        public void CTest(string input, string output)
        {
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"4 2 2
1 2 3 4
",
            @"6
")]
        [TestCase(
            @"3 1 2
1 3 5
",
            @"-1
")]
        public void DTest(string input, string output)
        {
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"6 4 3
3 1 4 1 5 9
",
            @"5 6 10
")]
        [TestCase(
            @"10 6 3
12 2 17 11 19 8 4 3 6 20
",
            @"21 14 15 13 13
")]
        public void ETest(string input, string output)
        {
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3
12 18 11
",
            @"16
")]
        [TestCase(
            @"10
0 0 0 0 0 0 0 0 0 0
",
            @"0
")]
        [TestCase(
            @"5
324097321 555675086 304655177 991244276 9980291
",
            @"805306368
")]
        public void FTest(string input, string output)
        {
            Utility.InOutTest(Tasks.F.Solve, input, output);
        }
    }
}
