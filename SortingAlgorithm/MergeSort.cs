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
        // 算法步骤：
        // 1. 申请空间，使其大小为两个已经排序序列之和，该空间用来存放合并后的序列；
        // 2. 设定两个指针，最初位置分别为两个已经排序序列的起始位置；
        // 3. 比较两个指针所指向的元素，选择相对小的元素放入到合并空间，并移动指针到下一位置；
        // 4. 重复步骤 3 直到某一指针达到序列尾；
        // 5. 将另一序列剩下的所有元素直接复制到合并序列尾。

        public static List<int> Sort(List<int> nums)
        {
            // 分而治之
            return null;
        }

        /// <summary>
        /// 分-分而(Divide)
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        static List<int> Divide(List<int> nums)
        {
            if (nums.Count <= 1)
                return nums;

            int mid = nums.Count / 2;
            List<int> left = new List<int>();  // 定义左侧List
            List<int> right = new List<int>(); // 定义右侧List
                                               // 以下兩個循環把 lst 分為左右兩個 List
            for (int i = 0; i < mid; i++)
                left.Add(nums[i]);

            for (int j = mid; j < nums.Count; j++)
                right.Add(nums[j]);

            left = Divide(left); // 这里为啥要再分多一次呢？
            right = Divide(right);

            return Merge(left, right);
        }
        /// <summary>
        /// 归并-治之(Conquer)
        /// </summary>
        /// <param name="left">左側List</param>
        /// <param name="right">右側List</param>
        /// <returns></returns>
        static List<int> Merge(List<int> left, List<int> right)
        {
            List<int> temp = new List<int>();
            while (left.Count > 0 && right.Count > 0)
            {
                if (left[0] <= right[0])
                {
                    temp.Add(left[0]);
                    left.RemoveAt(0);
                }
                else
                {
                    temp.Add(right[0]);
                    right.RemoveAt(0);
                }
            }
            if (left.Count > 0)
            {
                for (int i = 0; i < left.Count; i++)
                    temp.Add(left[i]);
            }
            if (right.Count > 0)
            {
                for (int i = 0; i < right.Count; i++)
                    temp.Add(right[i]);
            }
            return temp;
        }
    }
}
