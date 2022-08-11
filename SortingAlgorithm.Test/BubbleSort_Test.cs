using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace SortingAlgorithm.Test
{
    public class BubbleSort_Test
    {
        [Fact(Timeout = Expiration.Timeout)]
        public async void RunTest()
        {
            await Task.Run(() =>
            {
                foreach (var item in TestData.Cases)
                {
                    BubbleSort.Sort(item.Input);

                    Assert.Equal<int>(item.Expected, item.Input);
                }
            });
        }
    }
}
