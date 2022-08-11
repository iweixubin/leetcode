using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;

namespace SortingAlgorithm
{
    /// <summary>
    /// 希尔排序
    /// </summary>
    public static class ShellSort
    {
        // https://m.runoob.com/data-structures/shell-sort.html
        // https://www.runoob.com/w3cnote/shell-sort.html
        // https://zh.wikipedia.org/zh-cn/%E5%B8%8C%E5%B0%94%E6%8E%92%E5%BA%8F
        // https://www.bilibili.com/video/BV1LT4y137cK 视频比较明白
        
        // 希尔排序的基本思想是：
        // 先将整个待排序的记录序列分割成为若干子序列分别进行直接插入排序，
        // 待整个序列中的记录"基本有序"时，再对全体记录进行依次直接插入排序。

        // [ 13 14 94 33 82 25 59 94 65 23 45 27 73 25 39 10 ]

        // 假设我们以步长为5 开始进行排序
        // 13 14 94 33 82
        // 25 59 94 65 23
        // 45 27 73 25 39  
        // 10

        // 然后我们对 每列 进行排序：
        // 10 14 73 25 23
        // 13 27 94 33 39
        // 25 59 94 65 82
        // 45
        // 将上述四行数字，依序接在一起时我们得到： [ 10 14 73 25 23 13 27 94 33 39 25 59 94 65 82 45 ]

        // 然后再以 3步长 进行排序：
        // 10 14 73
        // 25 23 13
        // 27 94 33
        // 39 25 59
        // 94 65 82
        // 45

        // 然后我们对 每列 进行排序：
        // 10 14 13
        // 25 23 33
        // 27 25 59
        // 39 65 73
        // 45 94 82
        // 94

        // 最后以 1步长 进行排序（此时就是简单的插入排序了）。

        public static void Sort(int[] nums)
        {
            int gap = nums.Length / 2;// Donald Shell 最初建议步长选择为 n/2 并且对步长取半直到步长达到 1
            // 有更好的步长，请看 wiki

            while (gap > 0)
            {
                for (int col = 0; col < gap; col++) // col = column= 列
                {
                    // 假设有 7个数，那么步长为 3，
                    // 第一步踩在 [0]; 第二步踩在 [3]; 第三步踩在 [6];
                    // 对 [0] [3] [6] 进行排序
                    // 每踩一步，类似打扑克收到一张牌：
                    // 收到的第一张牌是 [0]，与手中的牌从左向右（从后向前，从大到小），对比，插入——不用排序
                    // 收到的第二张牌是 [3]，与手中的牌从左向右（从后向前，从大到小），对比，插入——与 [0] 比较~
                    // 收到的第三张牌是 [6]，与手中的牌从左向右（从后向前，从大到小），对比，插入——与 [3]，小的话，再与 [0] 比较~
                    // 为了统一，考虑收到第三张牌的情景
                    for (int i = col + gap; i < nums.Length; i += gap)
                    {
                        var current = nums[i];// 新收到的牌
                        var loc = i;
                        // loc - gap >= col 确保从从左向右（从后向前，从大到小）不会超出索引。
                        while (loc - gap >= col && current < nums[loc - gap])
                        {
                            nums[loc] = nums[loc - gap];// 前一张牌，往后（右）移
                            loc -= gap;// 从左向右（从后向前，从大到小），对比
                        }
                        // 已经找出正确的位置
                        nums[loc] = current;// 插入
                    }
                }

                gap /= 2; // Donald Shell 最初建议步长选择为 n/2 并且对步长取半直到步长达到 1
            }
        }
    }
}
