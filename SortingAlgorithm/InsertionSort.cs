using System;
using System.Collections.Generic;
using System.Text;

namespace SortingAlgorithm
{
    /// <summary>
    /// 插入排序
    /// </summary>
    public static class InsertionSort
    {
        // 动图演示：https://www.runoob.com/w3cnote/insertion-sort.html
        // 静图演示：https://m.runoob.com/data-structures/insertion-sort.html
        
        // 插入排序和打扑克牌时，从牌桌上逐一拿起扑克牌，在手上排序的过程相同。

        // 首先拿起第一张牌 5, 手上有 {5}
        // 拿起第二张牌 2, 把 2 insert 到手上的牌 {5}, 得到 {2 5}
        // 拿起第三张牌 4, 把 4 insert 到手上的牌 {2 5}, 得到 {2 4 5}
        // 以此类推

        // 插入排序都采用in-place在数组上实现。具体算法描述如下：
        // 1. 从第一个元素开始，该元素可以认为已经被排序
        // 2. 取出下一个元素，在已经排序的元素序列中从后向前扫描
        // 3. 如果该元素（已排序）大于新元素，将该元素移到下一位置
        // 4. 重复步骤3，直到找到已排序的元素小于或者等于新元素的位置
        // 5. 将新元素插入到该位置后
        // 6. 重复步骤2~5

        public static void Sort(int[] nums)
        {
            // 下标从 1 开始的原因，是因为第一张牌从 nums[0] 拿，这个时候手里只有一张牌，按分而治之的基线条件，一张牌时完美有序。
            for (int i = 1; i < nums.Length; i++)
            {
                // 2. 取出下一个元素
                // 当前收到的牌
                int current = nums[i];

                var j = i - 1; // j 往左是排序好的，也是手中的牌

                // 2. 在已经排序的元素序列中从后向前扫描
                // 与手上的牌，从右←到←左一一比较
                while (j >= 0 && nums[j] > current)
                {
                    // 3. 如果该元素（已排序）大于新元素，将该元素移到下一位置
                    nums[j + 1] = nums[j];
                    j--;// 标记查看再往左边一张牌
                }

                // 如果再往左边一张牌小，那么插入到该牌+1位置
                nums[j + 1] = current;
            }
        }
    }
}
