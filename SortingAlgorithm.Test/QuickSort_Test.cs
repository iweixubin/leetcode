using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

using Xunit;

namespace SortingAlgorithm.Test
{
    public class QuickSort_Test
    {
        [Fact(Timeout = Expiration.Timeout)]
        public async void RunTest()
        {
            await Task.Run(() =>
            {
                foreach (var item in TestData.Cases)
                {
                    QuickSort.Sort(item.Input);

                    Assert.Equal<int>(item.Expected, item.Input);
                }
            });
        }

        [Fact(Timeout = Expiration.Timeout)]
        public async void RunTest_Intelligible()
        {
            await Task.Run(() =>
             {
                 foreach (var item in TestData.Cases)
                 {
                     var ouput = QuickSort.Sort(item.Input.ToList()).ToArray();

                     Assert.Equal<int>(item.Expected, ouput);
                 }
             });
        }
    }
}
