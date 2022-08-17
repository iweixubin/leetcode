using System;
using System.Collections.Generic;
using System.Text;

namespace SortingAlgorithm
{
    /// <summary>
    /// 基数排序
    /// </summary>
    public static class RadixSort
    {
        // https://www.runoob.com/w3cnote/radix-sort.html
        // https://zh.wikipedia.org/wiki/%E5%9F%BA%E6%95%B0%E6%8E%92%E5%BA%8F

        // 算法过程：
        // 将所有待比较数值（正整数）统一为同样的数位长度，数位较短的数前面补零。
        // 然后，从 最低位开始，依次进行一次排序。这样从最低位排序一直到最高位排序完成以后，数列就变成一个有序序列。

        // 看起来蛮适合比较字符串

        // 怎么从最低位开始
        // 123
        // 789
        // 只比较个位，只要 %10 就可以了
        // 只比较十位，要先 /10  再 %10
        // 只比较百位，要先 /100 再 %10

        // 统一逻辑得：
        // 只比较个位，要先 /1   再 %10
        // 只比较十位，要先 /10  再 %10
        // 只比较百位，要先 /100 再 %10

        public static void Sort(int[] nums)
        {
            var buckets = new List<List<int>>(10);
            for (int i = 0; i < 10; i++)
            {
                buckets.Add(new List<int>());
            }

            var max = GetMaxValue(nums);

            for (int div = 1; div <= max; div = div * 10)
            {
                foreach (var b in buckets)
                    b.Clear();// 清空桶

                // 放进桶
                foreach (var n in nums)
                {
                    var bi = n / div % 10;
                    buckets[bi].Add(n);
                }

                // 桶展开回数组
                var index = 0;
                foreach (var bucket in buckets)
                {
                    foreach (var bv in bucket)
                    {
                        nums[index] = bv;
                        index++;
                    }
                }
            }
        }

        private static int GetMaxValue(int[] nums)
        {
            var max = nums[0];

            foreach (var i in nums)
            {
                if (i > max)
                    max = i;
            }

            return max;
        }
    }
}
