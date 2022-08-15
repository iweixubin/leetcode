using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;


namespace SortingAlgorithm.Test
{
    public class MergeSort_Test
    {
        [Fact(Timeout = Expiration.Timeout)]
        public async void RunTest()
        {
            await Task.Run(() =>
            {
                foreach (var item in TestData.Cases)
                {
                    var result = MergeSort.Sort(item.Input.ToList());

                    Assert.Equal<int>(item.Expected, result);
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
                    var result = MergeSort.Sort(item.Input);

                    Assert.Equal<int>(item.Expected, result);
                }
            });
        }

        [Fact(Timeout = Expiration.Timeout)]
        public async void RunTestFib()
        {
            // https://oeis.org/A000045
            var fibNums = new int[]{0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233,
            377, 610, 987, 1597, 2584, 4181, 6765, 10946, 17711, 28657, 46368, 75025,
            121393, 196418, 317811, 514229, 832040, 1346269, 2178309, 3524578, 5702887,
            9227465, 14930352, 24157817, 39088169, 63245986, 102334155};


            await Task.Run(() =>
            {
                for (int i = 0; i < fibNums.Length; i++)
                {
                    var expected = new List<int>();
                    for (int j = 0; j <= i; j++)
                        expected.Add(fibNums[j]);

                    var fib = Fib(i + 1);

                    Assert.Equal<int>(expected, fib);
                }
            });
        }

        private int[] Fib(int n)
        {
            if (n == 0)
                return new int[] { };

            if (n == 1)
                return new int[] { 0 };

            if (n == 2)
                return new int[] { 0, 1 };

            var fib = Enumerable.Repeat<int>(0, n).ToArray();
            fib[0] = 0;
            fib[1] = 1;

            for (int i = 2; i < n; i++)
                fib[i] = fib[i - 2] + fib[i - 1];

            return fib;
        }
    }
}
