using NUnit.Framework;

namespace Tests
{
    public class Tests
    {
        [Timeout(2000)]
        [TestCase(
            @"4
oo--
",
            @"Yes
",
            TestName = "{m}-1")]
        [TestCase(
            @"3
---
",
            @"No
",
            TestName = "{m}-2")]
        [TestCase(
            @"1
o
",
            @"Yes
",
            TestName = "{m}-3")]
        [TestCase(
            @"100
ooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooox
",
            @"No
",
            TestName = "{m}-4")]
        public void ATest(string input, string output)
        {
            Utility.InOutTest(Tasks.A.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3
0 1 1
1 0 0
0 1 0
1 1 0
0 0 1
1 1 1
",
            @"Yes
",
            TestName = "{m}-1")]
        [TestCase(
            @"2
0 0
0 0
1 1
1 1
",
            @"Yes
",
            TestName = "{m}-2")]
        [TestCase(
            @"5
0 0 1 1 0
1 0 0 1 0
0 0 1 0 1
0 1 0 1 0
0 1 0 0 1
1 1 0 0 1
0 1 1 1 0
0 0 1 1 1
1 0 1 0 1
1 1 0 1 0
",
            @"No
",
            TestName = "{m}-3")]
        public void BTest(string input, string output)
        {
            Utility.InOutTest(Tasks.B.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"5
8
1 1 1
1 2 4
1 1 4
2 4
1 1 4
2 4
3 1
3 2
",
            @"1 2
1 1 2
1 4
4
",
            TestName = "{m}-1")]
        [TestCase(
            @"1
5
1 1 1
1 2 1
1 200000 1
2 1
3 200000
",
            @"1 2 200000
1
",
            TestName = "{m}-2")]
        public void CTest(string input, string output)
        {
            Utility.InOutTest(Tasks.C.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"3
3
1 2
3
",
            @"1
12
",
            TestName = "{m}-1")]
        [TestCase(
            @"3
1 5
2
3
",
            @"5
",
            TestName = "{m}-2")]
        [TestCase(
            @"11
1 9
1 9
1 8
1 2
1 4
1 4
1 3
1 5
1 3
2
3
",
            @"0
",
            TestName = "{m}-3")]
        public void DTest(string input, string output)
        {
            Utility.InOutTest(Tasks.D.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"4 2 3 3 2
",
            @"665496236
",
            TestName = "{m}-1")]
        [TestCase(
            @"6 4 2 1 1
",
            @"1
",
            TestName = "{m}-2")]
        [TestCase(
            @"100 1 1 10 10
",
            @"264077814
",
            TestName = "{m}-3")]
        public void ETest(string input, string output)
        {
            Utility.InOutTest(Tasks.E.Solve, input, output);
        }

        [Timeout(2000)]
        [TestCase(
            @"4
1 1 2
1 2 9
2 1 8
3 2 3
",
            @"20
",
            TestName = "{m}-1")]
        [TestCase(
            @"1
1 1000000000 1
",
            @"1
",
            TestName = "{m}-2")]
        [TestCase(
            @"15
158260522 877914575 602436426
24979445 861648772 623690081
433933447 476190629 262703497
211047202 971407775 628894325
731963982 822804784 450968417
430302156 982631932 161735902
880895728 923078537 707723857
189330739 910286918 802329211
404539679 303238506 317063340
492686568 773361868 125660016
650287940 839296263 462224593
492601449 384836991 191890310
576823355 782177068 404011431
818008580 954291757 160449218
155374934 840594328 164163676
",
            @"1510053068
",
            TestName = "{m}-3")]
        public void FTest(string input, string output)
        {
            Utility.InOutTest(Tasks.F.Solve, input, output);
        }
    }
}
