using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;

namespace SortingAlgorithm
{
    /// <summary>
    /// 冒泡排序
    /// </summary>
    public static class BubbleSort
    {
        // 动画演习 https://www.runoob.com/w3cnote/bubble-sort.html

        // 算法步骤：
        // 比较相邻的元素。如果第一个比第二个大，就调换他们两个。
        // 对每一对相邻元素作同样的工作，从开始第一对到结尾的最后一对。这步做完后，最后的元素会是最大的数。
        // 针对所有的元素重复以上的步骤，除了最后一个。
        // 持续每次对越来越少的元素重复上面的步骤，直到没有任何一对数字需要比较。

        // 比较 [i] 与 [i+1] 的值，看是否需要调换

        // 点评：
        // 直观，但基本上是 O(n²) 的时间复杂度，遇到有序的，或者尾部是有序的，
        // 什么时候最快：当输入的数据已经是正序时；
        // 什么时候最慢：当输入的数据是反序时；

        public static void Sort(int[] nums)
        {
            bool exchanged = true;

            // 设想有多少个数字就要比较多少轮。
            // 如果在一轮比较中没有发送任何调换，那么说明整个数组已经是从小到大排序好了，不用再比较了~
            for (int i = 0; i < nums.Length; i++)
            {
                exchanged = false;

                // -1 是防止 j+1 索引超标
                // -i 是每进行完一轮，最后的元素会是最大的数。所以排除上一轮后面的
                for (int j = 0; j < nums.Length - 1 - i; j++)
                {
                    if (nums[j] > nums[j + 1])
                    {
                        Swap(ref nums[j], ref nums[j + 1]);

                        if (!exchanged) // 记录是否发生交换
                            exchanged = true;
                    }
                }

                if (!exchanged) // 判断一轮中是否发生调换，如果没有则说明整个数组已经是从小到大排序好了，不用再比较了~
                    return;
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
    }
}
