using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;

namespace SortingAlgorithm.Test
{
    public class QuickSort_Test
    {
        [Fact]
        public void RunTest()
        {
            foreach (var item in TestData.Cases)
            {
                QuickSort.Sort(item.Input);

                Assert.Equal<int>(item.Expected, item.Input);
            }
        }

        [Fact]
        public void RunTest_Intelligible()
        {
            foreach (var item in TestData.Cases)
            {
                var ouput = QuickSort.Sort(item.Input.ToList()).ToArray();

                Assert.Equal<int>(item.Expected, ouput);
            }
        }
    }
}
