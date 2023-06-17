using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"8
beginner
",
            @"bbeeggiinnnneerr
",
            TestName = "{m}-1")]
        [TestCase(
            @"3
aaa
",
            @"aaaaaa
",
            TestName = "{m}-2")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"1 0 1 1 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0
",
            @"13
",
            TestName = "{m}-1")]
        [TestCase(
            @"1 0 1 0 1 0 0 0 0 1 0 0 1 1 0 1 1 1 1 0 0 0 1 0 0 1 1 1 1 1 1 0 0 0 0 1 0 1 0 1 0 1 1 1 1 0 0 1 1 0 0 0 0 1 0 1 0 1 0 1 0 0 0 0
",
            @"766067858140017173
",
            TestName = "{m}-2")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3
1 1 3 2 3 2 2 3 1
",
            @"1 3 2
",
            TestName = "{m}-1")]
        [TestCase(
            @"1
1 1 1
",
            @"1
",
            TestName = "{m}-2")]
        [TestCase(
            @"4
2 3 4 3 4 1 3 1 1 4 2 2
",
            @"3 4 1 2
",
            TestName = "{m}-3")]
        public void CTest(string input, string output)
        {
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"5
1 100
1 300
0 -200
1 500
1 300
",
            @"600
",
            TestName = "{m}-1")]
        [TestCase(
            @"4
0 -1
1 -2
0 -3
1 -4
",
            @"0
",
            TestName = "{m}-2")]
        [TestCase(
            @"15
1 900000000
0 600000000
1 -300000000
0 -700000000
1 200000000
1 300000000
0 -600000000
1 -900000000
1 600000000
1 -100000000
1 -400000000
0 900000000
0 200000000
1 -500000000
1 900000000
",
            @"4100000000
",
            TestName = "{m}-3")]
        public void DTest(string input, string output)
        {
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }

        [Timeout(6000)]
        [TestCase(
            @"4 2 10
1 5
2 1
3 3
4 2
2 10
1 0
4 0
3 1
2 0
3 0
",
            @"5
6
8
8
15
13
13
11
1
0
",
            TestName = "{m}-1")]
        public void ETest(string input, string output)
        {
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }

        [Timeout(4000)]
        [TestCase(
            @"3 2
1 3
2 8
4 6
",
            @"12
",
            TestName = "{m}-1")]
        [TestCase(
            @"1 1
306
",
            @"0
",
            TestName = "{m}-2")]
        [TestCase(
            @"4 4
155374934 164163676 576823355 954291757
797829355 404011431 353195922 138996221
191890310 782177068 818008580 384836991
160449218 545531545 840594328 501899080
",
            @"102
",
            TestName = "{m}-3")]
        public void FTest(string input, string output)
        {
            Utility.InOutTest(Tasks.F.Solve, input, output);
        }
    }
}
