using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace SortingAlgorithm.Test
{
    public class InsertionSort_Test
    {
        [Fact]
        public void RunTest()
        {
            foreach (var item in TestData.Cases)
            {
                InsertionSort.Sort(item.Input);

                Assert.Equal<int>(item.Expected, item.Input);
            }
        }
    }
}
