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

        // 本例子是体现算法思维步骤的例子。
        // 怎么在一个数组上操作，做到 In-place(占用常数内存，不占用额外内存)，请看上面的链接~

        // 递归法（Top-down）
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

        // 迭代法（Bottom-up）
        public static List<int> Sort(int[] nums)
        {
            // 1. 将序列每相邻两个数字进行归并操作，形成 ceil(n/2) 个序列，排序后每个序列包含两/一个元素
            // 2. 若此时序列数不是1个则将上述序列再次归并，形成 ceil(n/4) 个序列，每个序列包含四/三个元素
            // 3. 重复步骤2，直到所有元素排序完毕，即序列数为1

            // 我的粗暴做法是：
            // 1. 将每个数字变成序列 放到队列中
            // 2. 抽出两个序列进行归并，将归并结果放回队列中
            // 3. 重复 步骤2，直到队列中只有1个序列

            Queue<List<int>> queue = new Queue<List<int>>();

            foreach (var item in nums)
                queue.Enqueue(new List<int>() { item });

            while (true)
            {
                if (queue.Count == 1)
                    break;

                // 将每相邻两个的序列进行归并操作

                // 挑选出相邻两个的序列
                var a = queue.Dequeue();
                var b = queue.Dequeue();

                // 归并操作后放回队列
                var combine = Merge(a, b);
                queue.Enqueue(combine);
            }

            return queue.Peek();
        }
    }
}
