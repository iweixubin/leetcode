using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Basic.Tests
{
    public class SelectionSort_Tests
    {
        [Fact]
        public void Sort_TwoNums()
        {
            var nums = new int[] { 7, 4 };
            var expected = new int[] { 4, 7 };

            var result = SelectionSort.Sort(nums);

            Assert.Equal<int>(expected, result);
        }

        [Fact]
        public void Sort_FiveNums()
        {
            var nums = new int[] { 5, 3, 6, 2, 10 };
            var expected = new int[] { 2, 3, 5, 6, 10 };

            var result = SelectionSort.Sort(nums);

            Assert.Equal<int>(expected, result);
        }
    }
}
