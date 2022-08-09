using System;
using System.Collections.Generic;
using System.Text;

namespace SortingAlgorithm
{
    /// <summary>
    /// 希尔排序，也称递减增量排序算法，是插入排序的一种更高效的改进版本。
    /// </summary>
    public static class ShellSort
    {
        // https://m.runoob.com/data-structures/shell-sort.html
        // https://www.bilibili.com/video/BV1LT4y137cK 视频比较明白

        // 希尔排序的基本思想是：
        // 先将整个待排序的记录序列分割成为若干子序列分别进行直接插入排序，
        // 待整个序列中的记录"基本有序"时，再对全体记录进行依次直接插入排序。
        public static void Sort(int[] nums)
        {
            int temp;

            int gap = 1;

            // 增量公式
            while (gap < nums.Length / 3)
            {
                gap = gap * 3 + 1; 
                // 当 nums.Length = 2 时，gap = 1
                // 当 nums.Length = 4 时，gap = 1

                // 当 nums.Length = 8 时，gap = 4
                // 当 nums.Length = 9 时，gap = 4
            }

            while (gap > 0)
            {
                for (int i = gap; i < nums.Length; i++)
                {
                    temp = nums[i];
                    int j = i - gap;
                    while (j >= 0 && nums[j] > temp)
                    {
                        nums[j + gap] = nums[j];
                        j -= gap;
                    }
                    nums[j + gap] = temp;
                }

                gap /= 3;
            }
        }
    }
}
