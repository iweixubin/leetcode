using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TopInterviewQuestions.Easy
{
    public class T_1010_RemoveDuplicates_Test
    {
        [Fact]
        public void TestA()
        {
            // 给定数组 nums = [1, 1, 2],
            // 函数应该返回新的长度 2, 并且原数组 nums 的前两个元素被修改为 1, 2。 
            int[] nums = new int[] { 1, 1, 2 };
            int len = new RemoveDuplicatesX().RemoveDuplicates(nums);

            Assert.Equal(2, len);

            var checkNums = new int[] { 1, 2 };
            for (int i = 0; i < len; i++)
            {
                if (nums[i] != checkNums[i])
                {
                    Assert.True(false);
                }
            }
        }

        [Fact]
        public void TestB()
        {
            // 给定 nums = [0,0,1,1,1,2,2,3,3,4],
            // 函数应该返回新的长度 5, 并且原数组 nums 的前五个元素被修改为 0, 1, 2, 3, 4。
            int[] nums = new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            int len = new RemoveDuplicatesX().RemoveDuplicates(nums);

            Assert.Equal(5, len);

            var checkNums = new int[] { 0, 1, 2, 3, 4 };
            for (int i = 0; i < len; i++)
            {
                if (nums[i] != checkNums[i])
                {
                    Assert.True(false);
                }
            }
        }

        [Fact]
        public void TestC()
        {
            // 测试用例 4 / 161 超时
            // 给定 nums = [1,1]
            // 长度 1,
            int[] nums = new int[] { 1, 1 };
            int len = new RemoveDuplicatesX().RemoveDuplicates(nums);

            Assert.Equal(1, len);

            var checkNums = new int[] { 1 };
            for (int i = 0; i < len; i++)
            {
                if (nums[i] != checkNums[i])
                {
                    Assert.True(false);
                }
            }
        }
    }
}
