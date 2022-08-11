using System;
using System.Collections.Generic;
using System.Text;

namespace SortingAlgorithm
{
    /// <summary>
    /// 归并排序，该算法是采用分治法（Divide and Conquer）的一个非常典型的应用。
    /// </summary>
    public static class MergeSort
    {
        // https://m.runoob.com/data-structures/merge-sort.html
        // https://www.runoob.com/w3cnote/merge-sort.html
        // https://zh.wikipedia.org/zh-cn/%E5%BD%92%E5%B9%B6%E6%8E%92%E5%BA%8F

        public static List<int> Sort(List<int> nums)
        {
            // 分而治之的步骤：
            // 1. 找出基线条件，这个条件必须尽可能简单
            // 零个，或一个数，就是完美的有序
            if (nums.Count <= 1)
                return nums;

            // 分而
            int mid = nums.Count / 2;
            List<int> left = new List<int>(mid);// 给 List 分配大小，有那么一点点的优化作用~
            List<int> right = new List<int>(nums.Count - mid);

            for (int i = 0; i < mid; i++)
                left.Add(nums[i]);

            for (int i = mid; i < nums.Count; i++)
                right.Add(nums[i]);

            // 治之
            left = Sort(left);
            right = Sort(right);

            return Merge(left, right);// 归并排序
        }
        /// <summary>
        /// 合并两个排序好的序列
        /// </summary>
        static List<int> Merge(List<int> left, List<int> right)
        {
            // 算法步骤：
            // 1. 申请空间，使其大小为两个已经排序序列之和，该空间用来存放合并后的序列；
            List<int> combine = new List<int>(left.Count + right.Count);

            // 2. 设定两个指针，最初位置分别为两个已经排序序列的起始位置；
            // 3. 比较两个指针所指向的元素，选择相对小的元素放入到合并空间，并移动指针到下一位置；
            // 4. 重复步骤 3 直到某一指针达到序列尾；
            while (left.Count > 0 && right.Count > 0)
            {
                if (left[0] <= right[0])
                {
                    combine.Add(left[0]);
                    left.RemoveAt(0);
                }
                else
                {
                    combine.Add(right[0]);
                    right.RemoveAt(0);
                }
            }

            // 5. 将另一序列剩下的所有元素直接复制到合并序列尾。
            if (left.Count > 0)
            {
                for (int i = 0; i < left.Count; i++)
                    combine.Add(left[i]);
            }
            if (right.Count > 0)
            {
                for (int i = 0; i < right.Count; i++)
                    combine.Add(right[i]);
            }

            return combine;
        }
    }
}
