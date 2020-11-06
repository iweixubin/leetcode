using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TopInterviewQuestions.Easy
{
    /// <summary>
    /// 删除排序数组中的重复项
    /// </summary>
    public class RemoveDuplicatesX
    {
        // 题目地址：https://leetcode-cn.com/leetbook/read/top-interview-questions-easy/x2gy9m

        /*
        给定一个排序数组，你需要在 原地 删除重复出现的元素，使得每个元素只出现一次，返回移除后数组的新长度。
        不要使用额外的数组空间，你必须在 原地 修改输入数组 并在使用 O(1) 额外空间的条件下完成。

        示例 1:
        给定数组 nums = [1, 1, 2],
        函数应该返回新的长度 2, 并且原数组 nums 的前两个元素被修改为 1, 2。 
        你不需要考虑数组中超出新长度后面的元素。

        示例 2:
        给定 nums = [0, 0, 1, 1, 1, 2, 2, 3, 3, 4],
        函数应该返回新的长度 5, 并且原数组 nums 的前五个元素被修改为 0, 1, 2, 3, 4。
        你不需要考虑数组中超出新长度后面的元素。
         
        说明:
        为什么返回数值是整数，但输出的答案是数组呢?
        请注意，输入数组是以「引用」方式传递的，这意味着在函数里修改输入数组对于调用者是可见的。
         */


        // 执行用时：676 ms, 在所有 C# 提交中击败了5.06% 的用户
        // 内存消耗：32.4 MB, 在所有 C# 提交中击败了96.37% 的用户
        public int RemoveDuplicates(int[] nums)
        {
            int len = nums.Length;
            if (len < 2)
                return len;

            int newLength = 1;
            int currentMaxValue = nums[0];

            int checkCount = 1;
            for (int i = 1; i < len; i++)
            {
                if (checkCount == len || nums[i] < currentMaxValue)
                    break;

                if (nums[i] == currentMaxValue)
                {
                    // 将方法内联，应该是提示效率的，
                    // 但只是减少了内存消耗~
                    // 所以...
                    var temp = nums[i];
                    for (int k = i; k < len; k++)
                    {
                        if (k + 1 == len)
                            break;

                        nums[k] = nums[k + 1];
                    }

                    nums[len - 1] = temp;
                    //

                    i--; // 将原有的移动到最后，然后还是要比较向前移的元素
                }
                else
                {
                    newLength++;
                    currentMaxValue = nums[i];
                }

                checkCount++;
            }

            return newLength;
        }

        /*
         思路比较清晰，但
         执行用时：712 ms, 在所有 C# 提交中击败了 5.06% 的用户
         内存消耗：32.6 MB, 在所有 C# 提交中击败了 62.60% 的用户
         */
        public int RemoveDuplicates_Clarity(int[] nums)
        {
            if (nums.Length < 2) // 考虑到特殊输入，直接返回~
                return nums.Length;

            // 思路：因为已经排序好，而且不能使用额外的数组空间
            // 所以用将数组中的元素移动~
            int newLength = 1;
            int currentMaxValue = nums[0];

            var checkCount = 1;// 对比的次数，不超过数组长度
            for (int i = 1; i < nums.Length; i++)
            {
                if (checkCount == nums.Length || nums[i] < currentMaxValue)
                    break;

                if (nums[i] == currentMaxValue)
                {
                    MoveToLast(nums, i);
                    i--; // 将原有的移动到最后，然后还是要比较向前移的元素
                }
                else
                {
                    newLength++;
                    currentMaxValue = nums[i];
                }

                checkCount++;
            }

            return newLength;
        }

        /// <summary>
        /// 将某个索引值移动到最后面，其它元素往前靠一格
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="index">要移数组最后的元素索引</param>
        /// <returns></returns>
        private void MoveToLast(int[] nums, int index)
        {
            var temp = nums[index];
            for (int i = index; i < nums.Length; i++)
            {
                if (i + 1 == nums.Length)
                    break;

                nums[i] = nums[i + 1];
            }

            nums[nums.Length - 1] = temp;
        }
    }
}
