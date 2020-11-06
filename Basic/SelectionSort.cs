using System;
using System.Collections.Generic;
using System.Text;

namespace Basic
{
    /// <summary>
    /// 选择排序(Selection sort)，是一种简单直观的排序算法，O(n^2)
    /// </summary>
    public static class SelectionSort
    {
        // 它的工作原理是：第一次从待排序的数据元素中选出最小（或最大）的一个元素，存放在序列的起始位置，
        // 然后再从剩余的未排序元素中寻找到最小（大）元素，然后放到已排序的序列的末尾。
        // 以此类推，直到全部待排序的数据元素的个数为零。

        /// <summary>
        /// 从数组中找出最小元素的索引
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="startIndex">从什么位置开始</param>
        /// <returns></returns>
        private static int SelectionSmallestIndex(int[] nums, int startIndex = 0)
        {
            int smallest = nums[startIndex]; // 用户存储最小的数字
            int smallestIndex = startIndex;  // 用户存储最小元素的索引~

            for (int i = startIndex; i < nums.Length; i++)
            {
                if (nums[i] < smallest)
                {
                    smallest = nums[i];
                    smallestIndex = i;
                }
            }

            return smallestIndex;
        }

        public static int[] Sort(int[] nums)
        {
            if (nums.Length == 0 || nums.Length == 1)
                return new int[] { };

            if (nums.Length == 2)
            {
                if (nums[0] < nums[1])
                    return new int[] { nums[0], nums[1] };
                else
                    return new int[] { nums[1], nums[0] };
            }

            // 不想改变原来的数组 xx，所以先复制~
            int[] result = new int[nums.Length];
            // 不推荐新数组
            for (int i = 0; i < nums.Length; i++)
                result[i] = nums[i];

            for (int i = 0; i < result.Length; i++)
            {
                int swapIndex = SelectionSmallestIndex(result, i);
                if (swapIndex != i)
                {
                    int temp = result[i];
                    result[i] = result[swapIndex];
                    result[swapIndex] = temp;
                }
            }

            return result;
        }


        public static void UnstableSort(int[] nums)
        {
            // 选择排序是不稳定的排序方法。
            // 不稳定是指会改变输入的数据，如将 nums 中的元素调换来调换去~
        }
    }
}
