using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Basic.Tests
{
    public class QuickSort_Tests
    {
        [Fact]
        public void Sort_TwoNums()
        {
            var nums = new int[] { 7, 4 };
            var expected = new int[] { 4, 7 };

            QuickSort.Sort(nums);

            Assert.Equal<int>(expected, nums);
        }

        [Fact]
        public void Sort_FiveNums()
        {
            var nums = new int[] { 5, 3, 6, 2, 10 };
            var expected = new int[] { 2, 3, 5, 6, 10 };

            QuickSort.Sort(nums);

            Assert.Equal<int>(expected, nums);
        }
    }
}
