using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace SortingAlgorithm.Test
{
    public class HeapSort_Test
    {
        [Fact(Timeout = Expiration.Timeout)]
        public async void RunTest()
        {
            await Task.Run(() =>
            {
                foreach (var item in TestData.Cases)
                {
                    HeapSort.Sort(item.Input);

                    Assert.Equal<int>(item.Expected, item.Input);
                }
            });
        }

        [Fact]
        public  void RunTestDebug()
        {
            HeapSort.Sort(new int[] { 4, 1, 3, 9, 7 });
        }
    }
}
