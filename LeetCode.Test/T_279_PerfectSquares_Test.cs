using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LeetCode
{
    public class T_279_PerfectSquares_Test
    {
        const int X12 = 12;
        const int X13 = 13;

        // 8328 是 LeetCode 测试用例 530 / 588 
        // 7929 是 LeetCode 测试用例 553 / 588 
        // 5374 是 LeetCode 测试用例 554 / 588
        // 这些值都很容易因为超时而不能通过 LeetCode 的测试用例
        const int X8328 = 8328;   // 3
        const int X7929 = 7929;   // 2
        const int X5374 = 5374;   // 3
        const int X34567 = 34567; // 4

        int Match(int x)
        {
            switch (x)
            {
                case X12:
                    return 3; // 12 = 4 + 4 + 4
                case X13:
                    return 2; // 13 = 4 + 9
                case X8328:
                    return 3;
                case X7929:
                    return 2;
                case X5374:
                    return 3;
                case X34567:
                    return 4;
                default:
                    break;
            }

            return 0;
        }


        [Theory]
        [InlineData(T_279_PerfectSquares_Test.X12)]
        [InlineData(T_279_PerfectSquares_Test.X13)]
        [InlineData(T_279_PerfectSquares_Test.X8328)]
        [InlineData(T_279_PerfectSquares_Test.X7929)]
        [InlineData(T_279_PerfectSquares_Test.X5374)]
        [InlineData(T_279_PerfectSquares_Test.X34567)]
        public void Recursion_Test(int value)
        {
            var expected = Match(value);
            var count = new PerfectSquares().Recursion(value);

            Assert.Equal(expected, count);
        }

        [Theory]
        [InlineData(T_279_PerfectSquares_Test.X12)]
        [InlineData(T_279_PerfectSquares_Test.X13)]
        [InlineData(T_279_PerfectSquares_Test.X8328)]
        [InlineData(T_279_PerfectSquares_Test.X7929)]
        [InlineData(T_279_PerfectSquares_Test.X5374)]
        [InlineData(T_279_PerfectSquares_Test.X34567)]
        public void RecursionMS_Test(int value)
        {
            var expected = Match(value);
            var count = new PerfectSquares().Recursion(value);

            Assert.Equal(expected, count);
        }

        [Theory]
        [InlineData(T_279_PerfectSquares_Test.X12)]
        [InlineData(T_279_PerfectSquares_Test.X13)]
        [InlineData(T_279_PerfectSquares_Test.X8328)]
        [InlineData(T_279_PerfectSquares_Test.X7929)]
        [InlineData(T_279_PerfectSquares_Test.X5374)]
        [InlineData(T_279_PerfectSquares_Test.X34567)]
        public void DP_Test(int value)
        {
            var expected = Match(value);
            var count = new PerfectSquares().Recursion(value);

            Assert.Equal(expected, count);
        }
    }


}