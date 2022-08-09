using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace SortingAlgorithm.Test
{
    public class BubbleSort_Test
    {
        [Fact]
        public void RunTest()
        {
            foreach (var item in TestData.Cases)
            {
                BubbleSort.Sort(item.Input);

                Assert.Equal<int>(item.Expected, item.Input);
            }
        }
    }
}
