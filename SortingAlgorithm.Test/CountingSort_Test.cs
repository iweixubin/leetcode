using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace SortingAlgorithm.Test
{
    public class CountingSort_Test
    {
        [Fact(Timeout = Expiration.Timeout)]
        public async void RunTest()
        {
            await Task.Run(() =>
            {
                foreach (var item in TestData.Cases)
                {
                    CountingSort.Sort(item.Input);

                    Assert.Equal<int>(item.Expected, item.Input);
                }
            });
        }

        [Fact(Timeout = Expiration.Timeout)]
        public async void RunTestB()
        {
            await Task.Run(() =>
            {
                foreach (var item in TestData.Cases)
                {
                    CountingSort.SortB(item.Input);

                    Assert.Equal<int>(item.Expected, item.Input);
                }
            });
        }
    }
}
