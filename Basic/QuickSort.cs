using System;
using System.Collections.Generic;
using System.Text;

namespace Basic
{
    public static class QuickSort
    {
        public static void Sort(int[] nums)
        {
            Sort(nums, 0, nums.Length - 1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="subFrom">不产生子数组，所以需要在原来的数组上标记从什么位置开始是子数组</param>
        /// <param name="subTo">子数组结束</param>
        private static void Sort(int[] nums, int subFrom, int subTo)
        {
            int len = subTo - subFrom;
            if (len == 0)
                return;

            int temp;

            if (len == 1)
            {
                if (nums[subFrom] > nums[subTo])
                {
                    temp = nums[subFrom];
                    nums[subFrom] = nums[subTo];
                    nums[subTo] = temp;
                }

                return;
            }

            int pivotIndex = subFrom; // 用起始作为，基准值
            // 如果比基准值小，那么和基准值调换位置，

            var checkCount = len + 1;
            var tail = subTo;
            for (int i = subFrom; i <= subTo; i++)
            {
                if (checkCount == 0)
                    break;

                checkCount--;

                if (i == subFrom)
                    continue; // 因为用其实作为基准值，所以第一个就是它自己，不用判断，跳过~

                // 如果当前值 小于等于基准值,移到基准值的左边
                if (nums[i] <= nums[pivotIndex])
                {
                    temp = nums[i];
                    nums[i] = nums[pivotIndex];
                    nums[pivotIndex] = temp;

                    pivotIndex = i;
                }
                else // 如果当前的值 大于 基准值，
                {
                    temp = nums[tail];
                    nums[tail] = nums[i];
                    nums[i] = temp;

                    tail--; // 比较过来，就不要再换回来了
                    i--; // 换过来的值要重新比较一下
                }
            }

            if (pivotIndex - 1 > 0)
                Sort(nums, subFrom, pivotIndex - 1);

            if (pivotIndex + 1 < subTo)
                Sort(nums, pivotIndex + 1, subTo);
        }
    }
}
