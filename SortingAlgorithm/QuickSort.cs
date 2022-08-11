using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;

namespace SortingAlgorithm
{
    /// <summary>
    /// 快速排序
    /// </summary>
    public static class QuickSort
    {
        // 动画演习 https://www.runoob.com/w3cnote/quick-sort-2.html
        // https://zh.wikipedia.org/wiki/%E5%BF%AB%E9%80%9F%E6%8E%92%E5%BA%8F

        // 快速排序使用分治法（Divide and conquer）策略来把一个串行（list）分为两个子串行（sub-lists）。
        // 分而治之的步骤：
        // 1. 找出基线条件，这个条件必须尽可能简单。
        // 2. 不断将问题分解(或者说缩小规模)，直到符合基线条件。

        // 算法步骤：
        // 1. 挑选基准值：从数列中挑出一个元素，称为“基准”（pivot），
        // 2. 分割：重新排序数列，所有比基准值小的元素摆放在基准前面，所有比基准值大的元素摆在基准后面（与基准值相等的数可以到任何一边）。
        //    在这个分割结束之后，对基准值的排序就已经完成，产生了两个子序列。
        // 3. 递归排序子序列：递归地将小于基准值元素的子序列和大于基准值元素的子序列排序。

        // 递归到最底部的判断条件是数列的大小是零或一，此时该数列显然已经有序。—— 分而治之的基线条件，这个条件必须尽可能简单。
        // 还有比零个或一个数简单的么~


        // 选出一个数，比这个数小的放左边，比这个数大的放右边，相等随便放。
        // 在左边又选出一个数...

        // 点评：
        // 在大多数情况下都比平均时间复杂度为 O(n logn) 的排序算法表现要更好。
        // 最坏状况下则需要 Ο(n2)；

        public static void Sort(int[] nums)
        {
            Sort(nums, 0, nums.Length - 1);
        }

        // 调整数组，并返回以哪个位置作为分区索引
        private static int Partition(int[] nums, int subFrom, int subTo)
        {
            var pivotIndex = subFrom; // 选择一个数作为基准

            // index 就是用来指出那边小过基准值，那边大过基准值
            var index = pivotIndex + 1;// +1的原因是跳过基准自己，不用自己与自己比较

            // index 遇到大于等于基准的就停留，
            // 等待 i 向右→移动，看看是否比基准值小，小于的就交换位置，然后 index 向右→移动
            for (int i = index; i <= subTo; i++)
            {
                if (nums[i] < nums[pivotIndex])
                {
                    Swap(ref nums[i], ref nums[index]);
                    index++;
                }
            }

            // 因为 index 指向的都是大于或等于基准值的，所以退一格是小过基准值的
            Swap(ref nums[pivotIndex], ref nums[index - 1]);

            return index - 1;
        }

        // 在数组的位置上调换，做到 In-place ：占用常数内存，不占用额外内存~
        // 为了不使用额外内存，需要标记子数组的起始位置和结束位置
        private static void Sort(int[] nums, int subFrom, int subTo)
        {
            if (subFrom < subTo)
            {
                var partitionIndex = Partition(nums, subFrom, subTo);
                Sort(nums, subFrom, partitionIndex - 1);
                Sort(nums, partitionIndex + 1, subTo);
            }
        }

        // 将方法编译成内联，减少调用堆栈
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void Swap(ref int x, ref int y)
        {// 虽然很多排序算法会用到这个，但还是采用复制，这样每个文件自己是完整的。
            int t;
            t = x;
            x = y;
            y = t;
        }

        // 容易理解，但耗内存！不推荐使用！
        public static List<int> Sort(List<int> nums)
        {
            // 分而治之的步骤：
            // 1. 找出基线条件，这个条件必须尽可能简单
            // 零个，或一个数，就是完美的有序
            if (nums.Count <= 1)
                return nums;

            int pivotValue = nums[0];// 取第一个值作为基准

            var less = new List<int>();   // 存放比基准小的
            var equal = new List<int>();  // 存放与基准相等的
            var greater = new List<int>();// 存放比基准大的

            foreach (var item in nums)
            {
                if (item < pivotValue)
                    less.Add(item);
                else if (item == pivotValue)
                    equal.Add(item);
                else
                    greater.Add(item);
            }

            var join = new List<int>();
            join.AddRange(Sort(less)); // 分而治之的步骤：2. 不断将问题分解(或者说缩小规模)，直到符合基线条件
            join.AddRange(equal);// 基准不用再递归了！
            join.AddRange(Sort(greater)); // 分而治之的步骤：2. 不断将问题分解(或者说缩小规模)，直到符合基线条件
            return join;
        }
    }
}
