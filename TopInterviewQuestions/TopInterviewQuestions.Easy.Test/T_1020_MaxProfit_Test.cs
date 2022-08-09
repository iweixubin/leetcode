using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TopInterviewQuestions.Easy
{
    public class T_1020_MaxProfit_Test
    {
        [Fact]
        public void TestA()
        {
            //输入: [7,1,5,3,6,4]
            //输出: 7
            var prices = new int[] { 7, 1, 5, 3, 6, 4 };
            var expected = 7;

            var profit = new MaxProfitX().MaxProfit(prices);

            Assert.Equal<int>(expected, profit);
        }

        [Fact]
        public void TestB()
        {
            //输入: [1,2,3,4,5]
            //输出: 4
            var prices = new int[] { 1, 2, 3, 4, 5 };
            var expected = 4;

            var profit = new MaxProfitX().MaxProfit(prices);

            Assert.Equal<int>(expected, profit);
        }

        [Fact]
        public void TestC()
        {
            //输入: [7,6,4,3,1]
            //输出: 0
            var prices = new int[] { 7, 6, 4, 3, 1 };
            var expected = 0;

            var profit = new MaxProfitX().MaxProfit(prices);

            Assert.Equal<int>(expected, profit);
        }

        [Fact]
        public void TestD()
        {
            //输入: [1,2]
            //输出: 1
            var prices = new int[] { 1, 2 };
            var expected = 1;

            var profit = new MaxProfitX().MaxProfit(prices);

            Assert.Equal<int>(expected, profit);
        }

        [Fact]
        public void TestE()
        {
            //输入: [2,1,2,0,1]
            //输出: 2
            var prices = new int[] { 2, 1, 2, 0, 1 };
            var expected = 2;

            var profit = new MaxProfitX().MaxProfit(prices);

            Assert.Equal<int>(expected, profit);
        }
    }
}
