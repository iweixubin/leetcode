using System;
using System.Collections.Generic;
using System.Text;

namespace TopInterviewQuestions.Easy
{
    public class MaxProfitX
    {
        // 题目地址：https://leetcode-cn.com/leetbook/read/top-interview-questions-easy/x2zsx1

        /*
         给定一个数组，它的第 i 个元素是一支给定股票第 i 天的价格。
         设计一个算法来计算你所能获取的最大利润。你可以尽可能地完成更多的交易（多次买卖一支股票）。
         注意：你不能同时参与多笔交易（你必须在再次购买前出售掉之前的股票）。

 
         示例 1:
         输入: [7,1,5,3,6,4]
         输出: 7
         解释: 在第 2 天（股票价格 = 1）的时候买入，在第 3 天（股票价格 = 5）的时候卖出, 这笔交易所能获得利润 = 5-1 = 4 。
             随后，在第 4 天（股票价格 = 3）的时候买入，在第 5 天（股票价格 = 6）的时候卖出, 这笔交易所能获得利润 = 6-3 = 3 。

         示例 2:
         输入: [1,2,3,4,5]
         输出: 4
         解释: 在第 1 天（股票价格 = 1）的时候买入，在第 5 天 （股票价格 = 5）的时候卖出, 这笔交易所能获得利润 = 5-1 = 4 。
             注意你不能在第 1 天和第 2 天接连购买股票，之后再将它们卖出。
             因为这样属于同时参与了多笔交易，你必须在再次购买前出售掉之前的股票。

         示例 3:
         输入: [7,6,4,3,1]
         输出: 0
         解释: 在这种情况下, 没有交易完成, 所以最大利润为 0。
 

         提示：
         1 <= prices.length <= 3 * 10 ^ 4
         0 <= prices[i] <= 10 ^ 4
         */

        // 执行用时：124 ms, 在所有 C# 提交中击败了20.88% 的用户
        // 内存消耗：24.7 MB, 在所有 C# 提交中击败了63.58% 的用户
        public int MaxProfit(int[] prices)
        {
            if (prices.Length == 1)
                return 0;

            bool hold = false; // 标注是否有买入
            int buy = 0;       // 记录买入的价格
            int profit = 0;    // 记录总利润

            for (int i = 0; i < prices.Length; i++)
            {
                // 判断是最后，如果是，有持股赶紧卖出~
                if (i + 1 == prices.Length)
                {
                    if (hold)
                        profit += (prices[i] - buy);// 卖出

                    break;
                }


                if (!hold)// 手上没有股票的时候，寻找买入机会
                {         // 不能用 buy == 0 来判断，因为测试用例中有 0 元的价格

                    // 价格为 0 的时候买入，升值前买入~
                    if (prices[i] == 0 || prices[i] < prices[i + 1])
                    {
                        buy = prices[i];// 买进
                        hold = true;
                    }
                }
                else
                {
                    if (prices[i] > prices[i + 1])
                    {
                        profit += (prices[i] - buy);// 卖出
                        buy = 0;
                        hold = false;
                    }
                }
            }

            return profit;
        }
    }
}
