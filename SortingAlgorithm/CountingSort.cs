using System;
using System.Collections.Generic;
using System.Text;

namespace SortingAlgorithm
{
    /// <summary>
    /// 计数排序
    /// </summary>
    public static class CountingSort
    {
        // https://www.runoob.com/w3cnote/counting-sort.html
        // 算法的步骤如下：
        // 1. 找出待排序的数组中最大和最小的元素
        // 2. 统计数组中每个值为i的元素出现的次数，存入数组 buckets 的 第 i-minValue 项中
        // 3. 反向填充目标数组

        // 最大值与最小值之差越小越好，重复数值越多越好

        public static void Sort(int[] nums)
        {
            // 找出待排序的数组中最大和最小的元素
            var (maxValue, minValue) = GetMaxMin(nums);

            // 创建 统计数组
            var bucketLen = maxValue - minValue + 1;
            int[] buckets = new int[bucketLen];

            // 统计
            foreach (var i in nums)
            {
                buckets[i - minValue]++;// 计数
            }

            // 反向填充目标数组
            var sourceIndex = 0;
            for (int i = 0; i < buckets.Length; i++)
            {
                var sourceValue = i + minValue;

                var count = buckets[i];// 当传入 {7,3} 那么会有 5个桶，有些桶的计数是 0

                for (int c = count; c > 0; c--)
                {
                    nums[sourceIndex] = sourceValue;
                    sourceIndex++;
                }
            }
        }

        private static (int max, int min) GetMaxMin(int[] nums)
        {
            var max = nums[0];
            var min = nums[0];

            foreach (var i in nums)
            {
                if (i > max)
                    max = i;

                if (i < min)
                    min = i;
            }

            return (max, min);
        }

        // 很多文章使用的是下面的例子
        public static void SortB(int[] nums)
        {
            var max = nums[0];
            foreach (var i in nums)
            {
                if (i > max)
                    max = i;
            }

            int[] buckets = new int[max + 1];

            for (int i = 0; i < nums.Length; i++)
            {
                // 原数组的数值，作为桶的索引（编号）
                // 然后桶的数值是计数
                buckets[nums[i]]++;
            }

            // 本来 for buckets 展开就好
            // 但有些人想到了骚操作~

            // 很多文章或代码示例没有讲清楚这一步骚操作的目的~
            // https://www.interviewcake.com/concept/java/counting-sort 这篇有，还有图解
            for (int i = 1; i <= max; i++)
            {
                // using the pre-computed indices （index的复数） to place each item in the right spot
                buckets[i] = buckets[i] + buckets[i - 1];
                // 本来桶记录的是数值的个数，
                // 经过这一步后，变成了
                // 桶记录的是数值排序后的位置，注意不是索引。位置是从 1 开始的，索引是从 0 开始的
                // 另外，前面我们是使用原数组的数值来作为桶的索引
                // 于是，就可以根据两个特性展开了~

                // 桶记录的是数值排序后的位置，注意不是索引。位置是从 1 开始的，索引是从 0 开始的
                // ↑ 上面这句话是我调试看出来的，从结果去推导原因了，貌似违反逻辑思维了
            }

            int[] output = new int[nums.Length];
            // 从后往前
            for (int i = nums.Length - 1; i >= 0; i--)
            {
                // 桶的索引是原数值，桶的值是数值排序后的索引位置
                output[buckets[nums[i]] - 1] = nums[i]; 
                buckets[nums[i]]--;
            }

            for (int i = 0; i < output.Length; i++)
                nums[i] = output[i];
        }
    }
}
