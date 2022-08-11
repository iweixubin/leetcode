using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;

namespace SortingAlgorithm
{
    /// <summary>
    /// 选择排序
    /// </summary>
    public static class SelectionSort
    {
        // 动画演习  https://www.runoob.com/w3cnote/selection-sort.html

        // 算法步骤：
        // 首先在未排序序列中找到最小（大）元素，存放到排序序列的起始位置。
        // 再从剩余未排序元素中继续寻找最小（大）元素，然后放到已排序序列的末尾。
        // 重复第二步，直到所有元素均排序完毕。

        // 1. 在数组中选择最小的那个放到 [0]
        // 2. 在剩下的数据中选择最小的那个放到 [1]

        // 点评：
        // 选择排序是一种简单直观的排序算法，无论什么数据进去都是 O(n²) 的时间复杂度。
        // 所以用到它的时候，数据规模越小越好。唯一的好处可能就是不占用额外的内存空间了吧。


        /// <summary>
        /// 从数组中找出最小元素的索引位置
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="startIndex">从什么位置开始</param>
        /// <returns>返回最小值的索引位置</returns>
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

        public static void Sort(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                int swapIndex = SelectionSmallestIndex(nums, i);
                if (swapIndex != i)
                {
                    Swap(ref nums[i], ref nums[swapIndex]);
                }
            }

            return;
        }


        private static void UnstableSort(int[] nums)
        {
            // 选择排序是不稳定的排序方法。
            // 即在原序列中，r[i]=r[j]，且r[i]在r[j]之前，而在排序后的序列中，r[i]仍在r[j]之前，则称这种排序算法是稳定的；否则称为不稳定的。
            // 如在数组 8，6，6，6，9，5，3 中，经过算法后，6 与 6 不会发生调换
        }

        // 将方法编译成内联，减少调用堆栈
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void Swap(ref int x, ref int y)
        {// 虽然很多排序算法会用到这个，但还是采用复制，这样每个文件自己是完整的
            int t;
            t = x;
            x = y;
            y = t;
        }
    }
}
